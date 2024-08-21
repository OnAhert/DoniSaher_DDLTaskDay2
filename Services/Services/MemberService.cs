using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MemberService
    {
        public readonly static MemberService Instance = new MemberService();
        private readonly UserRepository userRepository = UserRepository.Instance;

        static MemberService() { }

        public void AddNewMember(string username, string password)
        {
            var newMember = new Member()
            {
                Username = username,
                Password = password
            };

            userRepository.Save(newMember);
        }

        public void DisableMember(string username)
        {
            var userToDisable = userRepository.GetByUsername(username);

            if (userToDisable is null || userToDisable is not Member)
                return;

            var user = (Member)userToDisable;
            user.IsDisabled = true;
            userRepository.Save(user);
        }
        public void UpdatePassword(string username, string newMemberPassword)
        {
            var userToUpdate = userRepository.GetByUsername(username);

            if (userToUpdate is null || userToUpdate is not Member)
                return;

            var user = (Member)userToUpdate;
            user.Password = newMemberPassword;
            userRepository.Update(user);
        }
        public void DeleteMember(string username)
        {
            var userToDelete = userRepository.GetByUsername(username);

            if (userToDelete is null || userToDelete is not Member)
                return;

            var user = (Member)userToDelete;
            userRepository.Delete(user);
        }
    }
}
