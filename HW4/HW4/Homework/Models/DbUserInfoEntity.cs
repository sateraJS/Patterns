using HW4.Homework.Models.Interfaces;
using System;

namespace HW4.Homework.Models
{
    public class DbUserInfoEntity : IDbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
