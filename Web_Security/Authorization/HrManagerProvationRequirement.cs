using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Web_Security.Authorization
{    public class HrManagerProvationRequirement:IAuthorizationRequirement
    {
     public   int ProvationMonth;
        public HrManagerProvationRequirement(int provationMonth)
        {

            ProvationMonth = provationMonth;
               }
    }
    public class HrManagerProvationRequirementHandler : AuthorizationHandler<HrManagerProvationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HrManagerProvationRequirement requirement)
        {
           if(!context.User.HasClaim(x=>x.Type== "EmployeeDate"))
            {
                return Task.CompletedTask;
            }
            var empdate = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmployeeDate").Value);
            var period = DateTime.Now - empdate;
            if (period.Days > 30 * requirement.ProvationMonth)
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }



}
