1. ön gerekesinimleri kur

```
$  pip3 install ansible[azure]
$  ansible-galaxy install azure.azure_preview_modules
$  pip3 install -r ~/.ansible/roles/azure.azure_preview_modules/files/requirements-azure.txt
```

2. önce alttaki komutu çalıştır

```
$ ansible-playbook playbook_azure.yml
```

3. oluşan Vm lerin public iplerini inventory.yaml ve group_vars klasöründeki all.yaml dosyasında uygun yerlere yazıp alttaki komuu çalıştır. 

```
$ ansible-playbook playbook_azure_roles.yml -vvvv -i inventory.yml
```




### detaylar

Bnun için gerekli dosyları azure-ansible klasöründe bulabilirsiniz.

Ansible Azure Detaylartı İçin
- [Guide](https://docs.ansible.com/ansible/latest/scenario_guides/guide_azure.html)
- [Ansible Azure Modulleri için](https://docs.ansible.com/ansible/latest/modules/list_of_cloud_modules.html#azure)
- [Örnek Playbook lar için](https://github.com/Azure-Samples/ansible-playbooks)

playbook' u çalıştırmadan once ansible gerekli bağımlıklarını yükleyiniz.

```
$  pip3 install ansible[azure]
$  ansible-galaxy install azure.azure_preview_modules
$  pip3 install -r ~/.ansible/roles/azure.azure_preview_modules/files/requirements-azure.txt
```

Bütün sunuclara ssh veya username, password veya tercih edilen ssh la bağlanılabilmeli. 

bizim bu kurgumuzda linux makinlar create edilirken ssh pulic key zaten makinlara basılıyor.


Öncelikle group_vars klasöründeki all.yml dosyasından kaç makina ve özelliklerini belirtmek gerekiyor.

Çalıştırabilmek için bir kez azure cli ile azure hesabınıza giriş yapmalısınız.

Daha sonra alttaki komut ile azure da ki ortamımızı oluşturuyoruz. dikkat edilirse inventory belirtmiyoruz. çünki bu koıdlar zaten inventory oluşturmak için çalışıyor.

Eğer windows makinalara da ihtiyaç varsa playbook da ilgili açıklama satırları kapatılırsa verilen windows server bilgilerine göre bunları da oluşturacaktır.

```
$ ansible-playbook playbook_azure.yaml
```

Burada dikkat edilmesi gereken konu inventory.yml dosyasında worker ve master node lar belirlenmeli ve ip adresleri doğru girilmeli.

```
$ ansible-playbook playbook_azure_roles.yml -vvvv -i inventory.yaml
```
