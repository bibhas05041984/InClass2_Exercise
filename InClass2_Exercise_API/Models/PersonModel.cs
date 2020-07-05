using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 

namespace InClass2_Exercise_API.Models
{
    public class PersonModel
    {

        public string Name { get; set; }
        ///// <summary>
        ///// Gets or sets City.  
        ///// </summary>  

        public string City { get; set; }
        ///// <summary>
        ///// Gets or sets Gender. 
        ///// </summary>  

        public string Attending { get; set; }

        private static List<PersonModel> responses = new List<PersonModel>();
        public static IEnumerable<PersonModel> Responses
        {
            get
            {
                return responses;
            }
        }
        public static void AddResponse(PersonModel response)
        {
            responses.Add(response);
        }
 


    }
}