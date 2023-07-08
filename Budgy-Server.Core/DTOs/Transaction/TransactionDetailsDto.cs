using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgy_Server.Core.DTOs.Transaction
{
    public class TransactionDetailsDto
    {
        public string Id { get; set; } = null!;

        public string Amount { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Time { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
