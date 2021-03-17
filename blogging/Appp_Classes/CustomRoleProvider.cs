using blogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace blogging.Appp_Classes
{
    
    public class CustomRoleProvider : RoleProvider
    {

        BlogContext context = new BlogContext();

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {

            throw new NotImplementedException();

        }
        
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {

                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();

        }

        public override bool DeleteRole(string roleName,bool throwOnPopulatedRole)
        {
            throw new NotImplementedException(); 

        }

        public override string[] FindUsersInRole(string roleName,string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();

        }
        public override string[] GetRolesForUser(string username) // us is abbrv. of user
        {
            if(!string.IsNullOrEmpty(username))
            {
                USER us = context.USERs.FirstOrDefault(x => x.UserName == username);

                if(us !=null)
                {
                    return us.UserRoles == null ? new string[]
                    { } : us.UserRoles.Select(x => x.ROLE).Select(x => x.RoleName).ToArray();
                }

            }

            return  new string[] {};
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username,string roleName)
        {

            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
    }
}