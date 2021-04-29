using System.ComponentModel.DataAnnotations;

namespace Dapper.Helper
{
    public class DapperHelperOptions
    {
        [Required(ErrorMessage = "redis connection string is required")]
        public string ConnectionString { get; set; }
    }
}
