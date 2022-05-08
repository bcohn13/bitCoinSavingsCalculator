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

def get_price(url):
    req = get(url)
    #req = requests.get("https://www.ebay.com/itm/193174768018?epid=16029037217&_trkparms=ispr%3D1&hash=item2cfa1d0992:g:S3wAAOSwvsth4Jrv&amdata=enc%3AAQAGAAAA4Ekg1gWptljyqfSkNqa%2BMLF8vTDP3YiqS%2FLaOfo4ud%2BtjgYGK%2BpVXch3JUwKXosV0NYXQrHt%2FJiSw6S6freZfkqB%2F3afuW4zqPWNGpKugdd6Thbn%2Bb6WyW2olcWcy4jGifug8T%2BKPAzMviZodZpElcMtudPaHe%2Bp0jBUKl%2B7rRJnEvtPaFRjJIHFqP7Po%2FG6o5IyM5k6UmRp8T8bbLnKQY7SmYsAzyYKvI0xqvsVQbycHQP6sHB1RGmUq5%2BRmRYp%2FHnYJZrIRHJClFRL2F0dkdyDxRJtsc9fePRdFIWHyFtR%7Ctkp%3ABFBM2Jv3gZRg")
    cont=req.content
    soup = BeautifulSoup(cont, features="html.parser")
    item_price=soup.find("span",{"id":"prcIsum"})
    item_price_cleaned=re.sub(r'[^0-9.]','',item_price.text)
    return item_price_cleaned

def get_name(url):
    req = get(url)
    #req = requests.get("https://www.ebay.com/itm/193174768018?epid=16029037217&_trkparms=ispr%3D1&hash=item2cfa1d0992:g:S3wAAOSwvsth4Jrv&amdata=enc%3AAQAGAAAA4Ekg1gWptljyqfSkNqa%2BMLF8vTDP3YiqS%2FLaOfo4ud%2BtjgYGK%2BpVXch3JUwKXosV0NYXQrHt%2FJiSw6S6freZfkqB%2F3afuW4zqPWNGpKugdd6Thbn%2Bb6WyW2olcWcy4jGifug8T%2BKPAzMviZodZpElcMtudPaHe%2Bp0jBUKl%2B7rRJnEvtPaFRjJIHFqP7Po%2FG6o5IyM5k6UmRp8T8bbLnKQY7SmYsAzyYKvI0xqvsVQbycHQP6sHB1RGmUq5%2BRmRYp%2FHnYJZrIRHJClFRL2F0dkdyDxRJtsc9fePRdFIWHyFtR%7Ctkp%3ABFBM2Jv3gZRg")
    cont=req.content
    soup = BeautifulSoup(cont, features="html.parser")
    name_div=soup.find("div",{"id":"LeftSummaryPanel"})
    item_name=name_div.find("span",{"class":"ux-textspans ux-textspans--BOLD"})
    return item_name.text
    
if __name__=='__main__':
    
    print(get_name(sys.argv[1]),"LINEBREAK",get_price(sys.argv[1]),"LINEBREAK",datetime.now())
    #print(get_name(sys.argv[1]),"LINEBREAK",get_price(sys.argv[1]))
    sleep(1)
    os.system("cls")
    

