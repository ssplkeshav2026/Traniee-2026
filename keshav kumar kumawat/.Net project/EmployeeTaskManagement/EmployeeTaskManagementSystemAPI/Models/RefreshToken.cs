namespace EmployeeTaskManagementSystemAPI.Models
{
        public class RefreshToken
        {
            public int Id { get; set; }

            public string UserId { get; set; }
            public string Token { get; set; }

            public DateTime CreatedAt { get; set; } = DateTime.Now;
            public DateTime ExpiresAt { get; set; }
            public DateTime? RevokedAt { get; set; }

            public bool IsActive => RevokedAt == null && DateTime.Now < ExpiresAt;
        }
    }