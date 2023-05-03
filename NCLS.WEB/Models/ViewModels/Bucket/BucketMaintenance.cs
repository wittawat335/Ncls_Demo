using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCLS.WEB.Entities;

namespace NCLS.WEB.Models.ViewModels.Bucket
{
    public class BucketMaintenance
    {
        public M_BUCKET Bucket { get; set; }
        public string mode { get; set; }

        public BucketMaintenance()
        {

            Bucket = new M_BUCKET();
        }
    }
}