using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS1
{
    public class Ve2
    {
        public static List<Ve1> GetListTicketsByShowTimes(string idLicChieu)
        {
            List<Ve1> ve1s = new List<Ve1>();
            string query = "select * from Ve where idLichChieu = '" + idLicChieu + "'";
            DataTable data = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Ve1 ve1 = new Ve1(row);
                ve1s.Add(ve1);
            }
            return ve1s;
        }
        public static List<Ve1> GetListTicketsBoughtByShowTimes(string IdLichChieu)
        {
            List<Ve1> ve1s = new List<Ve1>();
            string query = "select * from Ve where idLichChieu = '" + IdLichChieu + "' and TrangThai = 1";
            DataTable data = DataProvider.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Ve1 ve1 = new Ve1(row);
                ve1s.Add(ve1);
            }
            return ve1s;
        }
        public static int BuyTicket(string ticketID, float price)
        {
            string query = "Update dbo.Ve set TrangThai = 1, TienBanVe = " + price + " where id = '" + ticketID + "'";
            return DataProvider.ExecuteNonQuery(query);
        }
        public static int BuyTicket1(string ticketID, string customerID, float price)
        {
            string query = "Update dbo.Ve set TrangThai = 1, idKhachHang = N'" + customerID + "', TienBanVe = " + price + " where id = '" + ticketID + "'";
            return DataProvider.ExecuteNonQuery(query);
        }


        public static int ThemVe(string idLichChieu, string seatName)
        {
            string query = "USP_InsertTicketByShowTimes @idlichChieu , @maGheNgoi";
            return DataProvider.ExecuteNonQuery(query, new object[] { idLichChieu, seatName });
        }

        public static int XoaVe(string idLichChieu )
        {
            string query = "USP_DeleteTicketsByShowTimes @idlichChieu";
            return DataProvider.ExecuteNonQuery(query, new object[] { idLichChieu });
        }

    }
}
