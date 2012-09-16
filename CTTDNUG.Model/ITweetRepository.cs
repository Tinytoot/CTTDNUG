using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTTDNUG.Model
{
    public interface ITweetRepository
    {
    
        void GetTweets(string searchPattern);  
    }
}
