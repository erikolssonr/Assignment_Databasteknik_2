using Assignment_Databasteknik.Entities;
using Assignment_Databasteknik.Models;
using Assignment_Databasteknik.Repositories;
using System.Diagnostics;

namespace Assignment_Databasteknik.Services;

internal class CustomerService
{
    private readonly AddressRepo _addressRepo;
    private readonly CustomerRepo _customerRepo;
    private readonly CustomerCategoryRepo _customerCategoryRepo;

    public CustomerService(AddressRepo addressRepo, CustomerRepo customerRepo, CustomerCategoryRepo customerCategoryRepo)
    {
        _addressRepo = addressRepo;
        _customerRepo = customerRepo;
        _customerCategoryRepo = customerCategoryRepo;
    }

    public async Task<bool> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        if (!await _customerRepo.ExistsAsync(x => x.Email == form.Email))
        {
            CustomerCategoryEntity customerCategoryEntity = await _customerCategoryRepo.CreateAsync(new CustomerCategoryEntity { CategoryType = form.CustomerCategory });

            AddressEntity addressEntity = await _addressRepo.GetAsync(x => x.StreetName == form.StreetName && x.PostalCode == form.PostalCode);
            addressEntity ??= await _addressRepo.CreateAsync(new AddressEntity { StreetName = form.StreetName, PostalCode = form.PostalCode, City = form.City });


            CustomerEntity customerEntity = await _customerRepo.CreateAsync(new CustomerEntity { FirstName = form.FirstName, LastName = form.LastName, Email = form.Email, AddressId = addressEntity.Id, CustomerCategoryId = customerCategoryEntity.Id });
            if (customerEntity != null)
                return true;
        }

        return false;
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        var customers = await _customerRepo.GetAllAsync();
        return customers;
    }

    public async Task<CustomerEntity> GetAsync(int id)
    {
        var customer = await _customerRepo.GetAsync(x => x.Id == id);
        return customer;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var result = await _customerRepo.DeleteAsync(x => x.Id == id);
        return result;  
    }

    public async Task UpdateAsync(int id)
    {
        try
        {
            var customer = await _customerRepo.GetAsync(x => x.Id == id);

            if (customer != null)
            {
                Console.Clear();
                Console.WriteLine("Update successful.");
                Console.ReadKey();
                await _customerRepo.UpdateAsync(customer);
            }

            else
            {
                Console.Clear();
                Console.WriteLine("The update failed, or no entity was found.");
                Console.ReadKey();
            }
        }
        catch (Exception ex) 
        {
            Debug.WriteLine(ex.Message);
        }

    }

}
