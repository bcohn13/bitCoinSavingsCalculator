# -*- coding: utf-8 -*-
"""
Created on Fri May  6 20:43:03 2022

@author: bcohn
"""
from requests import get
from bs4 import BeautifulSoup
from time import sleep
import sys,re,os
from datetime import datetime

bitcoin_url="https://finance.yahoo.com/quote/BTC-USD/"

def get_bitcoin_price(url):
    req = get(url)
    #req = requests.get("https://www.ebay.com/itm/193174768018?epid=16029037217&_trkparms=ispr%3D1&hash=item2cfa1d0992:g:S3wAAOSwvsth4Jrv&amdata=enc%3AAQAGAAAA4Ekg1gWptljyqfSkNqa%2BMLF8vTDP3YiqS%2FLaOfo4ud%2BtjgYGK%2BpVXch3JUwKXosV0NYXQrHt%2FJiSw6S6freZfkqB%2F3afuW4zqPWNGpKugdd6Thbn%2Bb6WyW2olcWcy4jGifug8T%2BKPAzMviZodZpElcMtudPaHe%2Bp0jBUKl%2B7rRJnEvtPaFRjJIHFqP7Po%2FG6o5IyM5k6UmRp8T8bbLnKQY7SmYsAzyYKvI0xqvsVQbycHQP6sHB1RGmUq5%2BRmRYp%2FHnYJZrIRHJClFRL2F0dkdyDxRJtsc9fePRdFIWHyFtR%7Ctkp%3ABFBM2Jv3gZRg")
    cont=req.content
    soup = BeautifulSoup(cont, features="html.parser")
    bitcoin_price=soup.find("fin-streamer",{"class":"Fw(b) Fz(36px) Mb(-4px) D(ib)"})
    bitcoin_price_cleaned=re.sub(r'[^0-9.]','',bitcoin_price.text)
    return bitcoin_price_cleaned
    
if __name__=='__main__':
    
    #print(datetime.now(),"LINEBREAK",get_bitcoin_price(bitcoin_url))
    print(get_bitcoin_price(bitcoin_url))
    sleep(1)
    os.system("cls")
    

