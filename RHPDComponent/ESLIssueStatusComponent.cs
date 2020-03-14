using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RHPDDalc;
using RHPDEntity;
using System.Data;

namespace RHPDComponent
{
    public class ESLIssueStatusComponent
    {

        public DataTable SelectIssueStatusComp(DateTime from, DateTime to)
        {
            try
            {
                DataTable dt;
                ESLIssueStatusDALC ObjStatusDALC = new ESLIssueStatusDALC();
                dt = ObjStatusDALC.SelectESLfilterDALC(from, to);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

       public DataTable SelectESLStausComponent(ESLIssueEntity ObjEntity)
        {
            try
            {
                DataTable dt;
                ESLIssueStatusDALC ObjStatusDALC = new ESLIssueStatusDALC();
                dt = ObjStatusDALC.SelectESLStausDALC(ObjEntity);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
