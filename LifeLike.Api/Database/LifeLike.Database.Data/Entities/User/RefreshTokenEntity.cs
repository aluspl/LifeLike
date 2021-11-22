using System;

namespace LifeLike.Database.Data.Entities.User
{
    public class RefreshTokenEntity : BaseEntity
    {
        public RefreshTokenEntity()
        {

        }

        public RefreshTokenEntity(string refreshToken)
        {
            RefreshToken = refreshToken;
        }

        public UserEntity User { get; set; }

        public Guid UserId { get; set; }

        public string RefreshToken { get; set; }
    }
}
