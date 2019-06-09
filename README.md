# Music-Downloader
一款简单的音乐下载（播放）器
功能：歌曲搜索、歌单读取、在线播放、歌曲下载（包括付费音乐）

作者：NiTian （QQ：1024028162）
## 使用技巧 
* 列表右键功能菜单
* 列表可配合Ctrl和Shift键实现多选
* 歌单ID示例
   * 网易云音乐：https://music.163.com/playlist?id=3778678
   * QQ音乐：https://y.qq.com/n/yqq/playsquare/7013848675.html
   * 酷狗音乐：https://www.kugou.com/yy/special/single/709458.html
   * 酷我音乐：http://www.kuwo.cn/playlist_detail/2780723818
   * 千千音乐：http://music.taihe.com/songlist/566242123
## 运行截图
<img src="https://github.com/NiTian1207/Music-Downloader/blob/master/MusicPlayer%20Material/%E6%88%AA%E5%9B%BE1.png" width="212" height="352.5‬"><img src="https://github.com/NiTian1207/Music-Downloader/blob/master/MusicPlayer%20Material/%E6%88%AA%E5%9B%BE2.png" width="212" height="352.5‬">

## 捐助
<img src="https://github.com/NiTian1207/Music-Downloader/blob/master/MusicPlayer%20Material/IMG_0019.JPG" width="300" height="450"><img src="https://github.com/NiTian1207/Music-Downloader/blob/master/MusicPlayer%20Material/IMG_0020.JPG" width="300" height="450">

## 更新日志: 
   * 1.3.3(2019年6月9日)：
      * 修复 下载音质问题
      * 修复 QQ音乐下载错误
      * 修复 播放音乐导致程序奔溃的问题
      * 增加 名称换位与分类 工具
      * 增加 下载音乐后修改音乐详细信息 功能
      * 更换 图标
      <br/>
   * 1.3.2(2019年6月2日):
      * 紧急更新（解决程序闪退）
      * 获取热门歌单
      * 同步歌词
      * 修复n个BUG
      <br/>
   * 1.3.1(2019年5月29日)：
      * 删除咪咕音乐音源（获取总是出错）
      * 增加千千音乐音源
      * 增加音质选择（酷狗音乐不支持）
      * 关闭酷狗音乐的歌单获取（不知道怎么突然获取不了了）
      * 增加获取专辑名称（为了这个功能把整个搜索功能全都重写了）
      * 优化播放列表的使用
      * 更改使用 .Net Framework 4.6 框架
      <br/>
   * 1.3.0（2019年5月27日）：
      * 主要有：重绘界面、增加播放功能、增加音源、优化使用、增加下载列表
      * 这次改动比较多，我自己都记不住了
      <br/>
   * 1.2.5（2019年4月29日）：
      * 单独创建搜索线程 优化体验
      * 修复因音乐名称中含有 : 导致的下载错误
      * 添加多项音乐选中下载（配合Shift/Ctrl）
      * 修改界面布局1.2.4（2019年4月22日）：
      * 更改软件名为Music Downloader
      * 添加酷狗音乐和QQ音乐接口
      * 修复BUG
      * 优化细节
      <br/>
   * 1.2.0（2019年4月21日）：
      * 修复了多数文件下载错误（这个问题是写代码的时候疏忽了，没想到保存的音乐文件名里有不能作为文件名的字符）
      * 修复N个BUG（我自己也不记得到底改了多少）
      * 优化细节（下载时列表自动下滑之类的小细节）
      * 增加了一个检测更新
      <br/>
   * 1.1.0（2019年4月18日）：
      * 更改下载保存的文件名为 歌名 - 歌手名
      * 更改歌词编码为ANSI
      * 在标题上加了个版本号 1.1.0
      * 取消每次下载错误都弹出消息框,更改为全部下载完成后一起显示
