using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crud : MonoBehaviour
{
    public GameObject itemParent, item, form_create;

    // Start is called before the first frame update
    void Start()
    {
        read();
    }

    public void read()
    {
        int count = PlayerPrefs.GetInt("count");

        for (int i = 0; i < itemParent.transform.childCount; i++)
        {

            Destroy(itemParent.transform.GetChild(i).gameObject);
        }

        int number = 0;
        for (int i = 0; i <= count; i++)
        {
            number++;
            string id = PlayerPrefs.GetString("id[" + i + "]");
            string nama = PlayerPrefs.GetString("nama[" + i + "]");
            string makanan = PlayerPrefs.GetString("makanan[" + i + "]");
            string jumlah = PlayerPrefs.GetString("jumlah[" + i + "]");
            string harga = PlayerPrefs.GetString("harga[" + i + "]");
            if (id != "")
            {
                GameObject tmp_item = Instantiate(itemParent, itemParent.transform);
                tmp_item.name = i.ToString();
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = number.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = nama;
                tmp_item.transform.GetChild(2).GetComponent<Text>().text = makanan;
                tmp_item.transform.GetChild(3).GetComponent<Text>().text = jumlah;
                tmp_item.transform.GetChild(4).GetComponent<Text>().text = harga;
            } else
            {
                number--;
            }
        }
    }

    public void create() 
    {
        int count = PlayerPrefs.GetInt("count");
        count++;
        PlayerPrefs.SetString("id[" + count + "]", count.ToString());
        PlayerPrefs.SetString("nama[" + count + "]", form_create.transform.GetChild(1).GetComponent<InputField>().text);
        PlayerPrefs.SetString("makanan[" + count + "]", form_create.transform.GetChild(2).GetComponent<InputField>().text);
        PlayerPrefs.SetString("jumlah[" + count + "]", form_create.transform.GetChild(3).GetComponent<InputField>().text);
        PlayerPrefs.SetString("harga[" + count + "]", form_create.transform.GetChild(4).GetComponent<InputField>().text);
        form_create.transform.GetChild(1).GetComponent<InputField>().text = "";
        form_create.transform.GetChild(2).GetComponent<InputField>().text = "";
        read();
    }

    public void delete() 
    {
        string id_perf = item.name;
        PlayerPrefs.DeleteKey("id[" +id_perf+ "]");
        PlayerPrefs.DeleteKey("nama[" + id_perf + "]");
        PlayerPrefs.DeleteKey("makanan[" + id_perf + "]");
        PlayerPrefs.DeleteKey("jumlah[" + id_perf + "]");
        PlayerPrefs.DeleteKey("harga[" + id_perf + "]");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
