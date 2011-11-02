using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Web;

namespace AddData
{
    

    class GetCoords
    {
        static String API_KEY = "ABQIAAAAHpeaaFwD04NAZ-z1qnw84BS7X6OjdHn3EoMwtcwgvUWyYecwERR1M2gVccrct2Uk437u9cs27uEH_g";

        /// <summary>
        /// Perform a geocode lookup of an address
        /// </summary>
        /// <param name="addr">The address in CSV form line1, line2, postcode</param>
        /// <param name="output">CSV or XML</param>
        /// <returns>LatLng object</returns>
        public LatLng GetLatLng(string addr)
        {
            if (String.IsNullOrEmpty(addr)) return null;


            String StrippedAddr = addr.Replace(' ', '+');


            var url = "http://maps.google.co.uk/maps/geo?output=csv&key=" +
                       API_KEY + "&q=" + StrippedAddr;

            var request = WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var ms = new MemoryStream();
                var responseStream = response.GetResponseStream();

                var buffer = new Byte[2048];
                int count = responseStream.Read(buffer, 0, buffer.Length);

                while (count > 0)
                {
                    ms.Write(buffer, 0, count);
                    count = responseStream.Read(buffer, 0, buffer.Length);
                }

                if (response.StatusCode != HttpStatusCode.OK && (addr.Contains("University") || addr.Contains("Univ")))
                {



                }


                responseStream.Close();
                ms.Close();

                var responseBytes = ms.ToArray();
                var encoding = new System.Text.ASCIIEncoding();

                var coords = encoding.GetString(responseBytes);
                var parts = coords.Split(',');

                if (Convert.ToDouble(parts[2]) != 0.0)
                {
                    Console.WriteLine(addr + "     Found Co-ords");
                    return new LatLng(
                                  Convert.ToDouble(parts[2]),
                                  Convert.ToDouble(parts[3]),
                                  addr);
                    

                }
                else
                {
                    Console.WriteLine(addr + "     Found Co-ords");
                }
            }

            return null;
        }



    }
}
