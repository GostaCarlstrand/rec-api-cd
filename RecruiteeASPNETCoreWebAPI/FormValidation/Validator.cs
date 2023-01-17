using System;
using System.Globalization;
using System.Text.RegularExpressions;
using RecruiteeASPNETCoreWebAPI.DAL.Models;

namespace RecruiteeASPNETCoreWebAPI.FormValidation
{
	public static class Validator
	{
		private static readonly int _maxCharEmail = 5;
		private static readonly int _maxCharName = 30;
		private static readonly int _maxCharPhone = 15;
		private static readonly int _maxCharLink = 30;
		private static readonly int _maxCharSocialLink = 30;

		public static bool isCandidateDataValid(Applicant applicant)
		{
			if (!isListValid(applicant.emails, _maxCharEmail))
			{
				return false;
			}
            if (!isListValid(applicant.links, _maxCharLink))
            {
                return false;
            }

            return true;
		}

        public static bool isPhoneValid(List<string> phones)
        { 
            
			foreach(var phone in phones)
			{
				if(!isNotEmpty(phone))
				{                    
					return false;
				}
				if(notEnoughChars(phone, _maxCharPhone))
				{                    
                    return false;
				}                                
            }

			return true;
		}
        public static bool isListValid(List<string> items, int maxItemChars) {
            
			foreach(var item in items)
			{
				if(!isNotEmpty(item))
				{
                    //empty field
					return false;
				}
				if(notEnoughChars(item, maxItemChars))
				{
                    //g@.
                    return false;
				}
                if (!IsValidEmail(item))
                {
                    //g--!@@.s
                    return false;
                }                
            }

			return true;
		}

		public static bool isNotEmpty(string item)
		{			
			return item.Length > 0;
		}
		public static bool notEnoughChars(string item, int minValue)
		{
            //Validates the minimum amount of characters on the item                       
            return item.Length < minValue;
		}
        public static bool IsValidEmail(string email)
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


    

    /*
        public string name { get; set; }
public List<string> emails { get; set; }
public List<string> phones { get; set; }
public List<string>? social_links { get; set; }
public List<string>? links { get; set; }
public string? cover_letter { get; set; }
{

    */



}

