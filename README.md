# Endpoint Listesi

## Ürünler (api/product)

[GET] /api/product/{_id} : 
Belirtilen id'ye ait ürün detayını getirir. Getirecek bir kayıt bulunmazsa, 404 response döner.

[POST] /api/product:
Yeni bir ürün ekler. İşlem tamamlandıktan sonra 201 response döner.

[PUT] /api/product/{_id}:
Belirtilen id'ye ait ürünü günceller. Ürün bulunmazsa, 404 response döner. Ürün güncellendiğinde 201 response döner.

[DELETE] /api/product/{_id}:
Belirtilen id'ye ait ürünü siler. Ürün bulunmazsa 404 response döner. 

## Kategoriler (api/category)

[GET] /api/category/{_id} :
Belirtilen id'ye ait kategori detayını getirir. Getirecek bir kayıt bulunmazsa, 404 response döner.

[POST] /api/category :
Yeni bir kategori ekler. İşlem tamamlandıktan sonra 201 response döner.

[PUT] /api/category/{_id} :
Belirtilen id'ye ait kategoriyi günceller. Kategori bulunmazsa, 404 response döner. Kategori güncellendiğinde 201 response döner.

[DELETE] /api/category/{_id} : 
Belirtilen id'ye ait kategoriyi siler. Kategori bulunmazsa 404 response döner.
