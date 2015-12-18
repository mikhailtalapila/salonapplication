using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccess.Context;
using DataAccess.Models;

namespace DataAccess.SampleData
{
   public class SalonSchedulerDatabaseInitializer:CreateDatabaseIfNotExists<SalonDbContext> // DropCreateDatabaseIfModelChanges<SalonDbContext>
   {
      protected override void Seed(SalonDbContext context)
      {
         //customers  
         /*
         Customer customer1 = new Customer();
         customer1.FirstName = "Larry";
         customer1.LastName = "Smith";
         customer1.PhoneNumber = "7329951111";
         customer1.AlternatePhoneNumber = "9089951111";
         customer1.Email = "larrysmith@email.com";
         customer1.Gender = "m";
         customer1.Remarks = "Remarks for customer1 Larry Smith";
         context.Customers.Add(customer1);

         Customer customer2 = new Customer();
         customer2.FirstName = "Joe";
         customer2.LastName = "Shmoe";
         customer2.PhoneNumber = "7329952222";
         customer2.AlternatePhoneNumber = "9089952222";
         customer2.Email = "joeshmoe@email.com";
         customer2.Gender = "m";
         customer2.Remarks = "Remarsk for customer2 Joe Shome";
         context.Customers.Add(customer2);

         Customer customer3 = new Customer();
         customer3.FirstName = "Mary";
         customer3.LastName = "Johnson";
         customer3.PhoneNumber = "7329953333";
         customer3.AlternatePhoneNumber = "9089953333";
         customer3.Email = "maryjohnson@email.com";
         customer3.Gender = "f";
         customer3.Remarks = "Remarks for customer3 Mary Johnson";
         context.Customers.Add(customer3);

         Customer customer4 = new Customer();
         customer4.FirstName = "Brian";
         customer4.LastName = "Hall";
         customer4.PhoneNumber = "6097771111";
         customer4.AlternatePhoneNumber = "9731111111";
         customer4.Email = "brianhall@email.com";
         customer4.Gender = "m";
         customer4.Remarks = "Remarks for customer4 Brian Hall";
         context.Customers.Add(customer4);

         Customer customer5 = new Customer();
         customer5.FirstName = "Katherine";
         customer5.LastName = "Scott";
         customer5.PhoneNumber = "6097772222";
         customer5.AlternatePhoneNumber = "9731112222";
         customer5.Email = "katherinescott@email.com";
         customer5.Gender = "f";
         customer5.Remarks = "Remarks for customer5 Katherine Scott";
         context.Customers.Add(customer5);

         Customer customer6 = new Customer();
         customer6.FirstName = "Stephen";
         customer6.LastName = "Washington";
         customer6.PhoneNumber = "6097773333";
         customer6.AlternatePhoneNumber = "9731113333";
         customer6.Email = "stephenwashington@email.com";
         customer6.Gender = "m";
         customer6.Remarks = "Remarks for customer6 Stephen Washington";
         context.Customers.Add(customer6);

         Customer customer7 = new Customer();
         customer7.FirstName = "Helen";
         customer7.LastName = "Colemna";
         customer7.PhoneNumber = "6097774444";
         customer7.AlternatePhoneNumber = "9731114444";
         customer7.Email = "helencoleman@email.com";
         customer7.Gender = "f";
         customer7.Remarks = "Remarks for customer7 Helen Coleman";
         context.Customers.Add(customer7);

         Customer customer8 = new Customer();
         customer8.FirstName = "Susan";
         customer8.LastName = "Simmons";
         customer8.PhoneNumber = "6097775555";
         customer8.AlternatePhoneNumber = "9731115555";
         customer8.Email = "susansimmons@email.com";
         customer8.Gender = "f";
         customer8.Remarks = "Remarks for customer8 Susan Simmons";
         context.Customers.Add(customer8);

         Customer customer9 = new Customer();
         customer9.FirstName = "Lisa";
         customer9.LastName = "Peterson";
         customer9.PhoneNumber = "6097776666";
         customer9.AlternatePhoneNumber = "9731116666";
         customer9.Email = "lisapeterson@email.com";
         customer9.Gender = "f";
         customer9.Remarks = "Remarks for customer9 Lisa Peterson";
         context.Customers.Add(customer9);

         Customer customer10 = new Customer();
         customer10.FirstName = "Lori";
         customer10.LastName = "Price";
         customer10.PhoneNumber = "6097777777";
         customer10.AlternatePhoneNumber = "9731117777";
         customer10.Email = "loriprice@email.com";
         customer10.Gender = "f";
         customer10.Remarks = "Remarks for customer10 Lori Price";
         context.Customers.Add(customer10);

         //employees
         Employee employee1 = new Employee();
         employee1.FirstName = "Kyle";
         employee1.LastName = "Lee";
         employee1.LastInitial = "L";
         employee1.PhoneNumber = "7329962311";
         employee1.AlternatePhoneNumber = "7329968300";
         employee1.Address = "Jackson, NJ";
         employee1.Title = "Owner, operator";
         employee1.Gender = "m";
         employee1.ImageSource = "employee1.jpg";
         employee1.Remarks = "Want the fastest, long lasting fill in the east? You've come to the right man. Specializes in permanent gel fills. Whether you choose French or color, you will be happy with the results.";
         context.Employees.Add(employee1);

         Employee employee2 = new Employee();
         employee2.FirstName = "Pam";
         employee2.LastName = "Lee";
         employee2.LastInitial = "L";
         employee2.PhoneNumber = "7329963500";
         employee2.AlternatePhoneNumber = "7329963211";
         employee2.Address = "Jackson, NJ";
         employee2.Title = "Owner, operator";
         employee2.Gender = "f";
         employee2.ImageSource = "employee12.jpg";
         employee2.Remarks = "Pam always makes sure the shop runs smoothly and tries to make your experience the most pleasant you've ever had.";         
         context.Employees.Add(employee2);

         Employee employee3 = new Employee();
         employee3.FirstName = "Joe";
         employee3.LastName = "Le";
         employee3.LastInitial = "L";
         employee3.PhoneNumber = "9084891111";
         employee3.AlternatePhoneNumber = "7324891111";
         employee3.Address = "Tinton Falls, NJ";
         employee3.Title = "Technician";
         employee3.Gender = "m";
         employee1.Gender = "m";employee3.ImageSource = "employee10.jpg";
         employee3.Remarks = "Ambitious and communicative. Joe is always up for a good conversation. He also does a great job on your nails.";
         context.Employees.Add(employee3);

         Employee employee4 = new Employee();
         employee4.FirstName = "Tammy";
         employee4.LastName = "Talapila";
         employee4.LastInitial = "T";
         employee4.PhoneNumber = "7329963578";
         employee4.AlternatePhoneNumber = "7329939321";
         employee4.Address = "Tinton Falls, NJ";
         employee4.Title = "Receptionist, technician";
         employee4.Gender = "f";
         employee4.ImageSource = "employee13.jpg";
         employee4.Remarks = "Want to feel special and not just be 'another client'? She, not only remembers your name, but accommodates with your appointments and listens to your problems. It's going beyond her job to make you feel like you're family.";
         context.Employees.Add(employee4);

         Employee employee5 = new Employee();
         employee5.FirstName = "Tenzin";
         employee5.LastName = "Guadaluplin";
         employee5.LastInitial = "G";
         employee5.PhoneNumber = "7329953333";
         employee5.AlternatePhoneNumber = "9089953333";
         employee5.Address = "Tinton Falls, NJ";
         employee5.Title = "Technician";
         employee5.Gender = "m";
         employee5.ImageSource = "employee8.jpg";
         employee5.Remarks = "Energetic and humorous. Tenzin is always in a good mood and won't allow you not to be in one. He will surely put a smile on your face.His customers love their pedicures.";
         context.Employees.Add(employee5);

         Employee employee6 = new Employee();
         employee6.FirstName = "Ping";
         employee6.LastName = "Lastname";
         employee6.LastInitial = "L";
         employee6.PhoneNumber = "7329954444";
         employee6.AlternatePhoneNumber = "9089954444";
         employee6.Address = "New Brunswick, NJ";
         employee6.Title = "Technician";
         employee6.Gender = "f";
         employee6.ImageSource = "employee11.jpg";
         employee6.Remarks = "Friendly and outgoing, she is always here to please her clients.Come experience.";
         context.Employees.Add(employee6);

         Employee employee7 = new Employee();
         employee7.FirstName = "Hanna";
         employee7.LastName = "Lastname";
         employee7.LastInitial = "L";
         employee7.PhoneNumber = "7329955555";
         employee7.AlternatePhoneNumber = "9089955555";
         employee7.Address = "East Brunswick, NJ";
         employee7.Title = "Technician";
         employee7.Gender = "f";
         employee7.ImageSource = "employee5.jpg";
         employee7.Remarks = "Hanna will go through great lengths to satisfy her clients. There is nothing she wouldn't do.";
         context.Employees.Add(employee7);

         Employee employee8 = new Employee();
         employee8.FirstName = "Tina";
         employee8.LastName = "Trung";
         employee8.LastInitial = "T";
         employee8.PhoneNumber = "7329956666";
         employee8.AlternatePhoneNumber = "9089956666";
         employee8.Address = "North Brunswick, NJ";
         employee8.Title = "Technician";
         employee8.Gender = "f";
         employee8.ImageSource = "employee2.jpg";
         employee8.Remarks = "Tina is always willing to assist you with all your needs. Come give her shellac manicures a try.Customers who did always come back.";
         context.Employees.Add(employee8);

         Employee employee9 = new Employee();
         employee9.FirstName = "Monica";
         employee9.LastName = "Moun";
         employee9.LastInitial = "M";
         employee9.PhoneNumber = "7329957777";
         employee9.AlternatePhoneNumber = "9089957777";
         employee9.Address = "Ocean, NJ";
         employee9.Title = "Technician";
         employee9.Gender = "f";
         employee9.ImageSource = "employee6.jpg";
         employee9.Remarks = "Have an affair to attend? Monica is always up on the latest trends.Come check out what she can do.";
         context.Employees.Add(employee9);

         Employee employee10 = new Employee();
         employee10.FirstName = "Eric";
         employee10.LastName = "Lee";
         employee10.LastInitial = "L";
         employee10.PhoneNumber = "7329958888";
         employee10.AlternatePhoneNumber = "9089958888";
         employee10.Address = "Freehold, NJ";
         employee10.Title = "Technician";
         employee10.Gender = "m";
         employee10.ImageSource = "employee3.jpg";
         employee10.Remarks = "Fast, efficient and a man of little words. His customers always refer him to their friends and colleagues.";
         context.Employees.Add(employee10 );

         Employee employee11 = new Employee();
         employee11.FirstName = "Tom";
         employee11.LastName = "Lastname";
         employee11.LastInitial = "L";
         employee11.PhoneNumber = "7329959999";
         employee11.AlternatePhoneNumber = "9089959999";
         employee11.Address = "Freehold, NJ";
         employee11.Title = "Technician";
         employee11.Gender = "m";
         employee11.ImageSource = "employee9.jpg";
         employee11.Remarks = "He's our 'TLC' man. He knows how to pamper the ladies to make them feel good and love their lives.";
         context.Employees.Add(employee11);

         Employee employee12 = new Employee();
         employee12.FirstName = "Lena";
         employee12.LastName = "Lastname";
         employee12.LastInitial = "L";
         employee12.PhoneNumber = "9089959999";
         employee12.AlternatePhoneNumber = "7329959999";
         employee12.Address = "Freehold, NJ";
         employee12.Title = "Technician";
         employee12.Gender = "f";
         employee12.ImageSource = "employee7.jpg";
         employee12.Remarks = "Do you have a design that you'd like? Lena can draw anything. Specializes in shellac and regular manicures.";
         context.Employees.Add(employee12);

         //service types / services
         context.ServiceTypes.Add(
            new ServiceType()
            {
               ServiceTypeId = 1,
               ServiceTypeName = "Manicures",
               Services = new List<Service>() 
               {
                  new Service { ServiceName= "Polish change", Price=7,ImageSource = "polishchange.jpg", Description = "Description of the polish change service here"},
                  new Service { ServiceName= "French Polish change", Price=12, ImageSource = "frenchpolishchange.jpg", Description = "Description of the french polish change service here" },
                  new Service { ServiceName= "Regular manicure", Price=12, ImageSource="regularmanicure.jpg", Description = "Description of the regular manicure service here" },
                  new Service { ServiceName= "French manicure", Price=17, ImageSource="frenchmanicure.jpg", Description="Description of the french manicure service here" },
                  new Service { ServiceName= "Buff manicure", Price=17, ImageSource="buffmanicure.jpg", Description="Description of the buff manicure here " },
                  new Service { ServiceName= "Shellac manicure", Price=27, ImageSource="shellacmanicure.jpg", Description="Description of the shellac manicure here" },
                  new Service { ServiceName= "French shellac manicure", Price=32, ImageSource="frenchshellacmanicure.jpg", Description="Description of the french shellcal manicure here" },
                  new Service { ServiceName= "Fill for permanent gel", Price=45, ImageSource="fillgel.jpg", Description="Description of the fill for permanent get service here" },
                  new Service { ServiceName= "Full set of permanent gel french", Price=85, ImageSource="fullsetgel.jpg", Description="Descirption of the full set of permanent gel service here" }
               }
            });
         context.ServiceTypes.Add(
            new ServiceType()
            {
               ServiceTypeId = 2,
               ServiceTypeName = "Pedicures",
               Services = new List<Service>() 
               {
                  new Service {ServiceName="Polish Change pedicure", Price=16, ImageSource="polishchangepedicure.jpg", Description="Description of the polish change pedicure service here" },               
                  new Service {ServiceName="French polish Change pedicure", Price=21, ImageSource="frenchpolishchangepedicure.jpg", Description="Description of the french polish change pedicure service here" },               
                  new Service {ServiceName="Spa pedicure", Price=27, ImageSource="spapedicure.jpg", Description="Description of the spa pedicure service here" },
                  new Service {ServiceName="Salt scrub pedicure", Price=32, ImageSource="saltscrubpedicure.jpg", Description="Description of the salt scrub pedicure service here" },
                  new Service {ServiceName="French pedicure", Price=32, ImageSource="frenchpedicure.jpg", Description="Description of the french pedicure service here" },
                  new Service {ServiceName="Shellac pedicure", Price=50, ImageSource="shellacpedicure.jpg", Description="Description of the shellac pedicure service here" },
                  new Service {ServiceName="Full set of permanent french gel pedicure", Price=100, ImageSource="fullsetgelpedicure.jpg", Description="Description of the permanent french get pedicure service here" }               
               }
            });
         context.ServiceTypes.Add(
            new ServiceType()
            {
               ServiceTypeId = 3,
               ServiceTypeName = "Waxing",
               Services = new List<Service>() 
               {
                  new Service {ServiceName="Lip wax", Price=7, ImageSource="lipwax.jpg", Description="Description of the lip wax service here" },               
                  new Service {ServiceName="Eyebrow wax", Price=8, ImageSource="eyebrowwax.jpg", Description="Description of the eyebrow wax service here" },               
                  new Service {ServiceName="Chin wax", Price=10, ImageSource="chinwax.jpg", Description="Description of the chin wax service here" },               
                  new Service {ServiceName="Sideburns wax", Price=10, ImageSource="sideburnswax.jpg", Description="Description of the sideburns wax service here" },               
                  new Service {ServiceName="Stomach wax", Price=10, ImageSource="stomachwax.jpg", Description="Description of the stomach wax service here" },               
                  new Service {ServiceName="Underarm wax", Price=16, ImageSource="underarmwax.jpg", Description="Description of the underarm wax service here" },               
                  new Service {ServiceName="1/2 arm wax", Price=25, ImageSource="halfarmwax.jpg", Description="Description of the 1/2 arm wax service here" },               
                  new Service {ServiceName="1/2 leg wax", Price=25, ImageSource="halflegwax.jpg", Description="Description of the 1/2 leg wax service here" },               
                  new Service {ServiceName="bikini wax", Price=25, ImageSource="bikiniwax.jpg", Description="Description of the bikini wax service here" },               
                  new Service {ServiceName="back wax", Price=30, ImageSource="backwax.jpg", Description="Description of the back wax service here" },               
                  new Service {ServiceName="Brazilian wax", Price=40, ImageSource="brazilianwax.jpg", Description="Description of the brazilian wax service here" },               
                  new Service {ServiceName="Full arm wax", Price=40, ImageSource="fullarmwax.jpg", Description="Description of the full arm wax service here" },               
                  new Service {ServiceName="Full leg wax", Price=40, ImageSource="fulllegwax.jpg", Description="Description of the full leg wax service here" },               
               }
            });
         context.ServiceTypes.Add(
            new ServiceType()
            {
               ServiceTypeId = 4,
               ServiceTypeName = "Massage",
               Services = new List<Service>() 
               {
                  new Service {ServiceName="10 minute massage", Price=15, ImageSource="10minutemassage.jpg", Description="Description of the 10 minute massage service here" },              
                  new Service {ServiceName="20 minute massage", Price=20, ImageSource="20minutemassage.jpg", Description="Description of the 20 minute massage service here" }               
               }
            });
                          
         //salon schedules
         SalonSchedule salonSchedule1 = new SalonSchedule();
         salonSchedule1.Start = new DateTime(2015, 09, 01, 05, 00, 00);
         salonSchedule1.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule1);
         SalonSchedule salonSchedule2 = new SalonSchedule();
         salonSchedule2.Start = new DateTime(2015, 09, 02, 05, 00, 00);
         salonSchedule2.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule2);
         SalonSchedule salonSchedule3 = new SalonSchedule();
         salonSchedule3.Start = new DateTime(2015, 09, 03, 05, 00, 00);
         salonSchedule3.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule3);
         SalonSchedule salonSchedule4 = new SalonSchedule();
         salonSchedule4.Start = new DateTime(2015, 09, 04, 05, 00, 00);
         salonSchedule4.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule4);
         SalonSchedule salonSchedule5 = new SalonSchedule();
         salonSchedule5.Start = new DateTime(2015, 09, 05, 05, 00, 00);
         salonSchedule5.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule5);         
         SalonSchedule salonSchedule8 = new SalonSchedule();
         salonSchedule8.Start = new DateTime(2015, 09, 08, 05, 00, 00);
         salonSchedule8.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule8);
         SalonSchedule salonSchedule9 = new SalonSchedule();
         salonSchedule9.Start = new DateTime(2015, 09, 09, 05, 00, 00);
         salonSchedule9.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule9);
         SalonSchedule salonSchedule10 = new SalonSchedule();
         salonSchedule10.Start = new DateTime(2015, 09, 10, 05, 00, 00);
         salonSchedule10.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule10);
         SalonSchedule salonSchedule11 = new SalonSchedule();
         salonSchedule11.Start = new DateTime(2015, 09, 11, 05, 00, 00);
         salonSchedule11.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule11);
         SalonSchedule salonSchedule12 = new SalonSchedule();
         salonSchedule12.Start = new DateTime(2015, 09, 12, 05, 00, 00);
         salonSchedule12.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule12);         
         SalonSchedule salonSchedule15 = new SalonSchedule();
         salonSchedule15.Start = new DateTime(2015, 09, 15, 05, 00, 00);
         salonSchedule15.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule15);
         SalonSchedule salonSchedule16 = new SalonSchedule();
         salonSchedule16.Start = new DateTime(2015, 09, 16, 05, 00, 00);
         salonSchedule16.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule16);
         SalonSchedule salonSchedule17 = new SalonSchedule();
         salonSchedule17.Start = new DateTime(2015, 09, 17, 05, 00, 00);
         salonSchedule17.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule17);
         SalonSchedule salonSchedule18 = new SalonSchedule();
         salonSchedule18.Start = new DateTime(2015, 09, 18, 05, 00, 00);
         salonSchedule18.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule18);
         SalonSchedule salonSchedule19 = new SalonSchedule();
         salonSchedule19.Start = new DateTime(2015, 09, 19, 05, 00, 00);
         salonSchedule19.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule19);
         SalonSchedule salonSchedule22 = new SalonSchedule();
         salonSchedule22.Start = new DateTime(2015, 09, 22, 05, 00, 00);
         salonSchedule22.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule22);
         SalonSchedule salonSchedule23 = new SalonSchedule();
         salonSchedule23.Start = new DateTime(2015, 09, 23, 05, 00, 00);
         salonSchedule23.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule23);
         SalonSchedule salonSchedule24 = new SalonSchedule();
         salonSchedule24.Start = new DateTime(2015, 09, 24, 05, 00, 00);
         salonSchedule24.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule24);
         SalonSchedule salonSchedule25 = new SalonSchedule();
         salonSchedule25.Start = new DateTime(2015, 09, 25, 05, 00, 00);
         salonSchedule25.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule25);
         SalonSchedule salonSchedule26 = new SalonSchedule();
         salonSchedule26.Start = new DateTime(2015, 09, 26, 05, 00, 00);
         salonSchedule26.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule26);
         SalonSchedule salonSchedule29 = new SalonSchedule();
         salonSchedule29.Start = new DateTime(2015, 09, 29, 05, 00, 00);
         salonSchedule29.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule29);
         SalonSchedule salonSchedule30 = new SalonSchedule();
         salonSchedule30.Start = new DateTime(2015, 09, 30, 05, 00, 00);
         salonSchedule30.Duration = 1020;
         context.SalonSchedules.Add(salonSchedule30);
                  
         //timeslots  //employee schedules
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 01, 8, 00, 00),
               Duration = 600,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=5}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 01, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=3 },
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=8},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 01, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2 },
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 02, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 02, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2},
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 03, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=8},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 03, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2},
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 04, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=8},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 04, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2},
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 05, 9, 00, 00),
               Duration = 480,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=4},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11},
                  new EmployeeSchedule { EmployeeId=12}
               }
            }
            );
         //week2
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 08, 8, 00, 00),
               Duration = 600,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=5}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 08, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=3 },
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=8},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 08, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2 },
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 09, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 09, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2},
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 10, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=8},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 10, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2},
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 11, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=8},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 11, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2},
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 12, 9, 00, 00),
               Duration = 480,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=4},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11},
                  new EmployeeSchedule { EmployeeId=12}
               }
            }
            );
         //week3
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 15, 8, 00, 00),
               Duration = 600,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=5}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 15, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=3 },
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=8},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 15, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2 },
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 16, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 16, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2},
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 17, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=8},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 17, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2},
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 18, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=8},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 18, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2},
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 19, 9, 00, 00),
               Duration = 480,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=4},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11},
                  new EmployeeSchedule { EmployeeId=12}
               }
            }
            );
         //week4
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 22, 8, 00, 00),
               Duration = 600,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=5}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 22, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=3 },
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=8},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 22, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2 },
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 23, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 23, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2},
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 24, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=8},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 24, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2},
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 25, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=8},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 25, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2},
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 26, 9, 00, 00),
               Duration = 480,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=4},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11},
                  new EmployeeSchedule { EmployeeId=12}
               }
            }
            );
         //week5
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 29, 8, 00, 00),
               Duration = 600,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=5}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 29, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=3 },
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=8},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 29, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2 },
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 30, 9, 00, 00),
               Duration = 540,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=1 },
                  new EmployeeSchedule { EmployeeId=3},
                  new EmployeeSchedule { EmployeeId=5},
                  new EmployeeSchedule { EmployeeId=6},
                  new EmployeeSchedule { EmployeeId=7},
                  new EmployeeSchedule { EmployeeId=9},
                  new EmployeeSchedule { EmployeeId=10},
                  new EmployeeSchedule { EmployeeId=11}
               }
            }
            );
         context.TimeSlots.Add(
            new TimeSlot()
            {
               Start = new DateTime(2015, 09, 30, 9, 00, 00),
               Duration = 360,
               EmployeeScheduleTimeSlots = new List<EmployeeSchedule>() 
               {
                  new EmployeeSchedule { EmployeeId=2},
                  new EmployeeSchedule { EmployeeId=4}
               }
            }
            );
          
      
         //qualifications added using the script
         //appointments added using the script

         base.Seed(context);
          */
      }
   }
}
