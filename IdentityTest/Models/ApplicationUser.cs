using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityTest.Models
{
    public class ApplicationUser : IdentityUser
    {

        //LD STEP1
        //LD this class inherits from "IdentityUser" class. 
        //This class holds the additional field for the identity user to store in the database. 
        public string NameLD { get; set; }

        public ApplicationUser() {
            //LD if I write "this." I can see all the fields available by the "IdentityUser" Class.
        }
        
    }
}
