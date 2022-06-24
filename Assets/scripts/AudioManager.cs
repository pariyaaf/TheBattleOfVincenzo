using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
//یه ابجکت جدا درست کردیم که اینو بهش بدیم 
//برای مدیریت صدا ها  کلا یه فایل جدا ایجاد میکنیم 
    
    
    
    //ببین اینو اینجا ساخته مثل رنگ ها که درستش کرده بود
    // اینج صدا اضافه میکنی از بخش اینسکتور
    // بهش اسم بدی و یه سری تنظیمات که توی همین اسکریپت مشخص شده. 

    public AudioSound[] sounds;

    //از اسکریت ایدیو منیجر یه شی ایجاد کردهپ
    //اینجوری میتونه توی این اسکریپت به کدهای اون یکی اسکریپت دسترسی داشته باشه
    public static AudioManager instance;
    
    //؟؟؟؟؟؟؟؟؟؟؟؟؟
    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (AudioSound s in sounds) {
            // برای هر شی که برای این لیست صدا ایجاد میشه اینارو میاد ایجاد میکنهذ 
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;//این صدا رو نگه میداره
            //اینا هر کدوم تنظیمات صدات که خب توی ادیوساند وجود دارن
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }

    }

    public void Play(string name) {
        AudioSound s = Array.Find(sounds , sounds => sounds.name == name);
        s.source.Play();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
