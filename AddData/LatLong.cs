using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddData
{
public class LatLng
{
    public String Organisation { get; set; }
    public double Latitude {get;set;}
    public double Longitude { get; set; }

    public LatLng(){
    }

    public LatLng(double lat, double lng, String org)
    {
        this.Latitude = lat;
        this.Longitude = lng;
        this.Organisation = org;
    }
}

}
