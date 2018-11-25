using System;
using System.Collections.Generic;
using DemoLibrary;

namespace ConsoleUI {
  class Program {
    static void Main (string[] args) {

      List<IProductModel> cart = AddSampleData ();
      CustomerModel customer = GetCustomer ();

      foreach (IProductModel prod in cart) {
        prod.ShipItem (customer);

        if (prod is IDigitalProductModel digital) {
          Console.WriteLine ($"For the {digital.Title} you have left {digital.TotalDownloadsLeft} downloads left");
        }
      }

    }

    private static CustomerModel GetCustomer () {
      return new CustomerModel {
        FirstName = "Matt",
          LastName = "Murdock",
          City = "Hell's Kitchen",
          EmailAddress = "Matt@Daredevil.com",
          PhoneNumber = "555-1212"
      };
    }

    private static List<IProductModel> AddSampleData () {
      List<IProductModel> output = new List<IProductModel> ();

      output.Add (new PhysicalProductModel { Title = "Nerf Football" });
      output.Add (new PhysicalProductModel { Title = "Daredevil T-Shirt" });
      output.Add (new PhysicalProductModel { Title = "Hard Drive" });

      output.Add (new DigitalProductModel { Title = "Lesson Source Code" });

      output.Add (new CourseProductModel { Title = ".NET Core Start to Finish" });

      return output;
    }

  }
}
