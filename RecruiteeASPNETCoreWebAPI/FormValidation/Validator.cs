using System;
using System.Globalization;
using System.Text.RegularExpressions;
using RecruiteeASPNETCoreWebAPI.DAL.Models;
using RecruiteeASPNETCoreWebAPI.Controllers;
using RecruiteeASPNETCoreWebAPI.PyPrinter;

namespace RecruiteeASPNETCoreWebAPI.FormValidation
{
	public static class Validator
	{
		private static readonly int _maxCharEmail = 30;
		private static readonly int _maxCharName = 30;
		private static readonly int _maxCharCoverLetter = 400;
		private static readonly int _maxCharPhone = 15;
		private static readonly int _maxCharLink = 30;
		private static readonly int _maxCharSocialLink = 30;

		
		private static readonly int _minCharName = 1;		        
		private static readonly int _defaultMinCharValue = 5;		        
		private static readonly int _defaultMaxCharValue = 30;
        
        

        public static bool isCandidateDataValid(Applicant applicant)
		{            
            if (!isInputValid(new List<string>() { applicant.name }, _maxCharName, _minCharName))            
                return false;                           
            if (!isInputValid(new List<string>() { applicant.cover_letter }, _maxCharCoverLetter))            
                return false;                
            if (!isInputValid(applicant.emails, _maxCharEmail, email: true))
                return false;
            if (!isInputValid(applicant.links, _maxCharLink))
                return false;
            if (!isInputValid(applicant.phones, _maxCharPhone))
                return false;
            if (!isInputValid(applicant.social_links, _maxCharSocialLink))
                return false;

            return false;
		}

        public static bool isInputValid(List<string> items, int maxItemChars = 30, int minItemChars = 5, bool email = false) {            
			foreach(var item in items)
			{
				if(!isNotEmpty(item))            
					return false;
				if(!isValidSize(item, maxItemChars, minItemChars))    
                    return false;
                if (email)
                    if (!IsContentValid(item))
                        return false;
                
            }
			return true;
		}

		public static bool isNotEmpty(string item)
		{			
			return String.IsNullOrEmpty(item);
		}

		public static bool isValidSize(string item, int maxVal, int minVal)
		{
            //Checks that items length is within a valid interval
            return item.Length < maxVal && item.Length >= minVal;
		}
        public static bool IsContentValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
	}
}