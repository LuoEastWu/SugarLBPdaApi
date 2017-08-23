using System;
using System.Linq;
using System.Text;

namespace Model.LBTable
{
    public class TaoBaoLevel
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public int ID {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public int? Level {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Rem {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:((1)) 
        /// Nullable:True 
        /// </summary>
        public int? Valid {get;set;}

    }
}
