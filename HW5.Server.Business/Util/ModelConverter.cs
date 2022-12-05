using HW5.Contracts.Response;
using HW5.Server.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Server.Business.Util
{
    public static class ModelConverter
    {
        
        public static IList<ClientListModel> GetClientsListModels(IList<Client> clients)
        {
            List<ClientListModel> result = new();

            foreach (var client in clients)
            {
                result.Add(
                    new()
                    {
                        Id = client.Id,
                        FullName = GetFullName(client),
                        BirthDate = client.BirthDate,
                        PhoneNumber = GetPhoneString(client.PhoneNumber)
                    });
            }
            return result;
        }

        public static ClientFullModel GetClientFullModel(Client client)
        {
            var result = new ClientFullModel
            {
                Id = client.Id,
                FirstName = client.FirstName,
                MiddleName = client.MiddleName,
                BirthDate = client.BirthDate,
                LastName = client.LastName,
                PhoneNumber = GetPhoneString(client.PhoneNumber),
            };
            if (client.Questionnaires != null && client.Questionnaires.Any())
            {
                result.Questionnaires = GetQuestionnaireListModels(client.Questionnaires.OrderBy(x => x.CreationDate).ToArray());
            }
            return result;
        }

        public static IList<OperatorListModel> GetOperatorListModels(IList<Operator> operators)
        {
            List<OperatorListModel> result = new();

            foreach (var oper in operators)
            {
                result.Add(
                    new()
                    {
                        Id = oper.Id,
                        FullName = GetFullName(oper),
                        BirthDate = oper.BirthDate,
                        PhoneNumber = GetPhoneString(oper.PhoneNumber),
                        JobTitle = oper.JobTitle.GetDisplayName(),
                        WorkExperience = oper.WorkExperience
                    });
            }
            return result;
        }

        public static OperatorFullModel GetOperatorFullModel(Operator oper)
        {
            var result = new OperatorFullModel
            {
                Id = oper.Id,
                FirstName = oper.FirstName,
                MiddleName = oper.MiddleName,
                LastName = oper.LastName,
                BirthDate = oper.BirthDate,
                PhoneNumber = GetPhoneString(oper.PhoneNumber),
                WorkExperience = oper.WorkExperience,
                JobTitle = oper.JobTitle.GetDisplayName()
            };
            if (oper.Questionnaires != null && oper.Questionnaires.Any())
            {
                result.Questionnaires = GetQuestionnaireListModels(oper.Questionnaires.OrderBy(x => x.CreationDate).ToArray());
            }
            return result;
        }

        public static IList<QuestionnaireListModel> GetQuestionnaireListModels(IList<Questionnaire> questionnaires)
        {
            List<QuestionnaireListModel> result = new();

            foreach (var questionnaire in questionnaires)
            {
                result.Add(
                    new()
                    {
                        Id = questionnaire.Id,
                        ClientFullName = (questionnaire.Client != null) ? GetFullName(questionnaire.Client) : string.Empty,
                        OperatorFullName = (questionnaire.Operator != null) ? GetFullName(questionnaire.Operator) : string.Empty,
                        CreationDate = questionnaire.CreationDate
                    });
            }
            return result;
        }

        public static QuestionnaireFullModel GetQuestionnaireFullModel(Questionnaire questionnaire)
        {
            return new QuestionnaireFullModel
            {
                Id = questionnaire.Id,
                ClientId = questionnaire.ClientId,
                ClientFullName = (questionnaire.Client != null) ? GetFullName(questionnaire.Client) : string.Empty,
                OperatorId = questionnaire.OperatorId,
                OperatorFullName = (questionnaire.Operator != null) ? GetFullName(questionnaire.Operator) : string.Empty,
                ClientIncome = questionnaire.ClientIncome,
                PaymentAbiliry = questionnaire.PaymentAbiliry,
                CreditsCount = questionnaire.CreditsCount,
                DepositesCount = questionnaire.DepositesCount,
                CreationDate = questionnaire.CreationDate
            };
        }

        private static string GetPhoneString(ulong phoneNumeric)
        {
            var baseString = phoneNumeric.ToString();
            //Проверка на стандартную длинну российского телефона
            if (baseString.Length == 10)
            {
                return $"+{baseString.Substring(0, 1)}({baseString.Substring(1, 3)}){baseString.Substring(3, 3)}-{baseString.Substring(6, 2)}-{baseString.Substring(8, 2)}";
            }
            else
            {
                return baseString;
            }
        }
        private static string GetFullName<TPerson>(TPerson person) where TPerson : Person
        {
            StringBuilder builder = new StringBuilder(person.LastName).Append(' ');
            if (string.IsNullOrEmpty(person.MiddleName))
            {
                builder.Append(person.FirstName);
            }
            else
            {
                builder.Append(person.FirstName.First()).Append('.').Append(person.MiddleName.First()).Append('.');
            }
            return builder.ToString();
        }
    }
}
