using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using RestApi.Models;

namespace Campus.SOPMobilityOnline.RestApi.Controllers
{
    public class MoUserController : ApiController
    {
        [HttpGet]
        public async Task<List<MoUser>> GetAllAccepted()
        {

            var moUsers = new List<MoUser>();
            var tasks = new List<Task>();
            var lockList = new object();
            DateTime dateInPass = new DateTime(1970,01,01);
            for (var i = 0; i < 1000; i++)
            {
                var j = i;
                tasks.Add(Task.Run(() =>
                {

                    var moUser = new MoUser
                    {
                        FirstName = $"FirstName_{j}",
                        Birthday = dateInPass.AddDays(j)
                    };
                    lock (lockList)
                        moUsers.Add(moUser);
                }));
            }

            var taskAllFinished = Task.WhenAll(tasks);
            await taskAllFinished;
            return moUsers;
        }
    }
}
