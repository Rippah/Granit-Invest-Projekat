using System;
using System.Collections.Generic;
using System.Data;
using GranitInvest.Repository;
using TravelAgency.Model;

namespace GranitInvest.ViewModel
{
    public class GatheringsViewModel : ViewModelBase
    {

        private readonly GatheringsRepository _gatheringsRepository = new GatheringsRepository();

        public DataView Skupovi
        {
            get
            {
                var dt = new DataTable();
                dt = _gatheringsRepository.GetAll(dt);
                ConvertGatheringsColumn(dt, "Link", typeof(string), "Link");

                return dt.DefaultView;
            }
        }

        public string LoadCurrentUsername => "Dobrodošli: " + CurrentUser.Username;

        public string GetConvertedRow(string gatheringsParameter, DataRow row, string columnName)
        {
            return gatheringsParameter switch
            {
                "Link" => "Link",
                _ => ""
            };
        }

        public void ConvertGatheringsColumn(DataTable dt, string columnName, Type newType, string gatheringsParameter)
        {
            var textList = new List<string>();

            foreach (DataRow row in dt.Rows)
                textList.Add(GetConvertedRow(gatheringsParameter, row, columnName));

            dt.Columns.Remove(columnName);
            var dc = new DataColumn(columnName, newType);
            dt.Columns.Add(dc);
            dc.SetOrdinal(dt.Columns[columnName]!.Ordinal);

            var i = 0;
            foreach (DataRow row in dt.Rows)
            {
                row[columnName] = textList[i++];
            }
        }
    }
}
