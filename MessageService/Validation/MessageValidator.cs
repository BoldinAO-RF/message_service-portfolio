using FluentValidation;
using MessageService.Contract;
using MessageService.Repositories;
using System.Linq;

namespace MessageService.Validation
{
    public class MessageValidator : AbstractValidator<MessageViewModel>
    {
        private IMessageRepository _messageRepository;
        private IUserRepository _userRepository;

        public MessageValidator(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;

            RuleFor(m => m.UserId)
                .Must((userId) => {
                    return UserExist(userId);
                })
                .WithMessage("User is not exist");

            RuleFor(m => m.MessageText)
                .Must((text) =>
                {
                    return TextIsNotEmpty(text);
                })
                .WithMessage("Message must be not empty");
        }

        private bool UserExist(int userId)
        {
            if (_userRepository.GetUsers().Where(a => a.Id == userId).Any())
                return true;
            return false;
        }

        private bool TextIsNotEmpty(string text)
        {
            if (text == "")
                return false;
            return true;
        }
    }
}
