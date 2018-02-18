using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//LD STEP6
namespace IdentityTest.ClamData
{
        public static class ClaimData
        {
            public static List<string> UserClaims { get; set; } = new List<string> { "Add User", "Edit User", "Delete User" };
        }
}
