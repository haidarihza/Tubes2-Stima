# Tugas Besar 2 Strategi Algoritma: Folder Crawler

Membuat *Folder Crawler* menggunakan algoritma *BFS* dan *DFS*.

## Deskripsi
Dalam tugas besar ini, Anda akan diminta untuk membangun sebuah aplikasi GUI sederhana 
yang dapat memodelkan fitur dari file explorer pada sistem operasi, yang pada tugas ini disebut 
dengan Folder Crawling. Dengan memanfaatkan algoritma Breadth First Search (BFS) dan Depth 
First Search (DFS), Anda dapat menelusuri folder-folder yang ada pada direktori untuk 
mendapatkan direktori yang Anda inginkan. Anda juga diminta untuk memvisualisasikan hasil dari 
pencarian folder tersebut dalam bentuk pohon.
Selain pohon, Anda diminta juga menampilkan list path dari daun-daun yang bersesuaian dengan 
hasil pencarian. Path tersebut diharuskan memiliki hyperlink menuju folder parent dari file yang 
dicari, agar file langsung dapat diakses melalui browser atau file explorer. 

## Requirement

## Build

Aplikasi dapat di-*build* dengan dua cara, sebagai `.exe` dengan beberapa file ekstensi, atau sebagai satu file `.exe` dan tidak membutuhkan apapun.

### Build (Multiple Files)

```
make build
```

Aplikasi akan terbagi menjadi satu `.exe` dan beberapa `.dll`. Untuk menjalankan `.exe` nya diperlukan `.dll`-nya.

### Build (One File)

```
make compile
```

Aplikasi berupa file `.exe` dan tidak memerlukan file tambahan.

## Run

File yang membutuhkan ekstensi berada di `bin\Debug\net6.0-windows\Stima2.exe` dan file tunggal berada di `bin/Publish/Stima2.exe`. 

Dapat dilakukan compile dan run sekaligus dengan command:

```
make build-run
```

dan

```
make compile-run
```

## Anggota

| Nama                      | NIM       |
| ----                      | ---       |
| Rizky Akbar Asmaran       | 13520111  |
| Muhammad Alif Putra Yasa  | 13520135  |
| Haidar Ihzaulhaq          | 13520150  |
