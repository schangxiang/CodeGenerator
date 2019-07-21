using System; 
using System.Text;
using System.Collections.Generic; 
namespace Maticsoft.Model{
	 	//udtWip_CodeSets
		public class udtWip_CodeSets
	{
   		     
      	/// <summary>
		/// 代码编码
        /// </summary>		
		private string _code;
        public string code
        {
            get{ return _code; }
            set{ _code = value; }
        }        
		/// <summary>
		/// 代码名称
        /// </summary>		
		private string _name;
        public string name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
		/// <summary>
		/// 说明
        /// </summary>		
		private string _note;
        public string note
        {
            get{ return _note; }
            set{ _note = value; }
        }        
		/// <summary>
		/// 删除标记
        /// </summary>		
		private bool _delflag;
        public bool delFlag
        {
            get{ return _delflag; }
            set{ _delflag = value; }
        }        
		/// <summary>
		/// 创建人
        /// </summary>		
		private string _creator;
        public string creator
        {
            get{ return _creator; }
            set{ _creator = value; }
        }        
		/// <summary>
		/// 创建时间
        /// </summary>		
		private DateTime _createtime;
        public DateTime createTime
        {
            get{ return _createtime; }
            set{ _createtime = value; }
        }        
		/// <summary>
		/// 修改人
        /// </summary>		
		private string _lastmodifier;
        public string lastModifier
        {
            get{ return _lastmodifier; }
            set{ _lastmodifier = value; }
        }        
		/// <summary>
		/// 修改时间
        /// </summary>		
		private DateTime _lastmodifytime;
        public DateTime lastModifyTime
        {
            get{ return _lastmodifytime; }
            set{ _lastmodifytime = value; }
        }        
		   
	}
}

