using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backendgema.Base;
using Backendgema.Helper;
using Backendgema.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backendgema.Services
{
    public class JenisLokasiService
    {
        private Koneksi _koneksi = new Koneksi();

        public BaseRespon<List<JenisLokasi>> get()
        {
            var hasil = new BaseRespon<List<JenisLokasi>>
            {
                status = true,
                message = new List<string>(),
                payload = _koneksi.JenisLokasis.ToList()
            };
            return hasil;
        }

        public BaseRespon<JenisLokasi> detail(String jenis)
        {
            BaseRespon<JenisLokasi> hasil = new BaseRespon<JenisLokasi>();
            JenisLokasi j = _koneksi.JenisLokasis.FirstOrDefault(x => x.Jenis_Lokasi.Equals(jenis));
            if (j == null)
            {
                hasil.status = false;
                hasil.message = new List<string>();
                hasil.message.Add(Konstan.DATA_TIDAK_DITEMUKAN);
                hasil.payload = null;
            }
            else
            {
                hasil.status = true;
                hasil.message = new List<string>();
                hasil.message.Add(Konstan.DATA_DITEMUKAN);
                hasil.payload = j;
            }

            return hasil;
        }

        public BaseRespon<JenisLokasi> add(JenisLokasi model)
        {
            var x = new BaseRespon<JenisLokasi>();
            x.message = new List<string>();
            var y = _koneksi.JenisLokasis.FirstOrDefault(a => a.Jenis_Lokasi.Equals(model.Jenis_Lokasi));
            if (y == null)
            {
                _koneksi.JenisLokasis.Add(model);
                _koneksi.SaveChanges();
                x.status = true;
                x.message.Add(Konstan.DATA_BERHASIL_DISIMPAN);
                x.payload = model;
            }
            else
            {
                x.status = false;
                x.message.Add(Konstan.DATA_DUPLIKAT);
                x.message.Add(Konstan.DATA_GAGAL_DISIMPAN);
                x.payload = null;
            }

            return x;
        }

        public BaseRespon<JenisLokasi> edit(JenisLokasi model)
        {
            var x = new BaseRespon<JenisLokasi>();
            x.message = new List<string>();
            var y = _koneksi.JenisLokasis.FirstOrDefault(a => a.Jenis_Lokasi.Equals(model.Jenis_Lokasi));
            if (y == null)
            {
                x.status = false;
                x.message.Add(Konstan.DATA_TIDAK_DITEMUKAN);
                x.payload = null;
            }
            else
            {
                y.Keterangan = model.Keterangan;
                _koneksi.SaveChanges();
                x.status = true;
                x.message.Add(Konstan.DATA_BERHASIL_DIEDIT);
                x.payload = model;
            }

            return x;
        }

        public BaseRespon<JenisLokasi> hapus(String jenis)
        {
            var x = new BaseRespon<JenisLokasi>();
            x.message = new List<string>();
            var y = _koneksi.JenisLokasis.FirstOrDefault(a => a.Jenis_Lokasi.Equals(jenis));
            if (y == null)
            {
                x.status = false;
                x.message.Add(Konstan.DATA_TIDAK_DITEMUKAN);
                x.payload = null;
            }
            else
            {
                _koneksi.JenisLokasis.Remove(y);
                _koneksi.SaveChanges();
                x.status = true;
                x.message.Add(Konstan.DATA_BERHASIL_DIHAPUS);
                x.payload = y;
            }

            return x;
        }

        
    }
}
