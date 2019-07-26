using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLDemo.Models.Entities
{
    public class BP_EmpInfo
    {
        [Key]
        public int Id { get; set; }

        public long? xid { get; set; }

        [Column("xdate")]
        public DateTime? Date { get; set; }

        [Column("xtype")]
        public string Event { get; set; }

        public string Badge { get; set; }

        [Column("xname")]
        public string Name { get; set; }

        public string ORGANAREAS_OLD { get; set; }

        public string ORGANAREAS_NEW { get; set; }

        public string Dep_OLD { get; set; }

        [Column("DEP_NEW")]
        public string Department { get; set; }

        public string Job_OLD { get; set; }

        [Column("JOB_NEW")]
        public string Job { get; set; }

        public string grade { get; set; }

        public string course { get; set; }

        public string tel { get; set; }

        public string email { get; set; }

        public DateTime? xjoindate { get; set; }

        public DateTime? xleavedate { get; set; }

        public DateTime? xchandate { get; set; }

        public int dealstatus { get; set; }

        public DateTime? dealdate { get; set; }

        public string emailnew { get; set; }

        public string upcusername { get; set; }

        public int sendmsgtime { get; set; }

        public DateTime syncdate { get; set; }

        public string REPORTTO { get; set; }

        public DateTime? xclosedtime { get; set; }

        public int? sex { get; set; }

        public DateTime? birthday { get; set; }

        public string CITY_OLD { get; set; }

        public string CITY_NEW { get; set; }

        public string OLDPOSITION { get; set; }

        public string NEWPOSITION { get; set; }

        [Column("jobgrade")]
        public int? JobGrade { get; set; }

        public string personemail { get; set; }

    }
}
