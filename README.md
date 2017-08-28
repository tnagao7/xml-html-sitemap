# XML&HTML Sitemap

## Overview

XML&HTML Sitemap is a Windows application for generating XML and HTML sitemaps.

Generated XML files (sitemap.xml) conform to the [Sitemaps XML format](https://www.sitemaps.org/protocol.html), 
and thus you can submit them to services such as Google Webmaster Tools without change. 
Generated HTML sitemaps (sitemap.html) can be freely altered and published in your websites.

![screen shot](https://github.com/tnagao7/xml-html-sitemap/raw/master/XmlHtmlSitemap/doc/img/main-window.png)

## Features

* Sitemap generation from local files
* Customizable template files for HTML sitemaps

## Requirements

* Windows 2000, XP, Vista, 7, etc.
* .NET Framework 2.0 or later

## Usage

1. Specify a **URL** of your website in the URL text box.
2. Specify a folder to save sitemaps in the **Save in** text box.
3. Turn on the following check boxes:
  - **Generate sitemap.xml**: To generate an XML sitemap.
  - **Generate sitemap.html**: To generate an HTML sitemap.
4. Click **Run**, then sitemap generation executed.

Turning on the Generate from local files check box, 
you can generate sitemaps from local files. 
In this case, sitemaps is generated without accessing the actual website. 

For more information, see the HTML documentation (XmlHtmlSitemap/doc/index.html).

## Third Party Notices

This program uses the following third-party libraries.

* [Html Agility Pack](http://html-agility-pack.net/)

For license information, refer to [THIRDPARTY.txt](THIRDPARTY.txt).
