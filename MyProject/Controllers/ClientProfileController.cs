using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClientProfileController : ControllerBase
  {
    public class ClientProfile
    {
      public int ClientProfileId { get; set; }
      public string Name { get; set; }
      public bool? HiddenInBackOffice { get; set; }
    }

    // GET: api/ClientProfile
    [HttpGet]
    public IEnumerable<ClientProfile> Get()
    {
      //getting client profiles from the database
      using (var connection = new SqlConnection("Server=GamingDb5;Database=Bingo;User Id=sa;Password=!@#$%A1;"))
      {
        string sql = "select * from dbo.tb_ClientProfile";
        var clientProfiles = connection.Query<ClientProfile>(sql);
        return clientProfiles;
      }
    }

    // GET: api/ClientProfile/5
    [HttpGet("{id}", Name = "Get")]
    public IEnumerable<ClientProfile> Get(int id)
    {
      using (var connection = new SqlConnection("Server=GamingDb5;Database=Bingo;User Id=sa;Password=!@#$%A1;"))
      {
        string sql = "SELECT * FROM tb_ClientProfile WHERE clientProfileId = @id;";
        var clientProfileID = connection.Query<ClientProfile>(sql, new {id});
        return clientProfileID;
      }        
    }

    // POST: api/ClientProfile
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/ClientProfile/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
