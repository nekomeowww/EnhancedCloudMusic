using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CloudMusicHelper
{
    class HistoryInterface
    {
        //Constructor
    }

    #region 网易云本地API文档
    /******************************************************************************************************
     * 
     *                             网易云音乐 历史播放记录 API指南
     *
     * 这是一个在代码文件中的迷你文档，用于快速帮助开发者定位history文件的键值，详细的文档可以到GitHub的repo上查看w
     * 
     *     |- fm                                私人FM的fm判定值，true即为此项来自私人FM，不存在即为此项不来自私人FM
     *     |- data                              不明数据，在不同模式下会有不同值，示例值：34799039，dailyrecommend
     *     |- fid                               不明数据，fid，在正常播放模式下会有值
     *     |- id                                私人FM的ID，在非私人FM模式下，此处有一个长ID，字符串
     *     |- track                             track列，一个键值列表，其中包含曲目的详细数据
     *        |- name                           曲目名字
     *        |- id                             曲目ID
     *        |- position                       曲目在专辑中的曲目号，同track.no
     *        |- alias                          一个数组，曲目别名
     *        |- status                         不明数据
     *        |- fee                            费用，数字
     *        |- copyrightId                    不明数据，版权ID
     *        |- disc                           专辑碟号
     *        |- no                             曲目在专辑中的曲目号，同track.postion
     *        |- artists                        artists数组，一个数组，其中包含了此曲目的作曲家
     *           |- name                        艺术家名字
     *           |- id                          艺术家ID
     *           |- picId                       艺术家图片ID
     *           |- img1v1Id                    不明数据，数字，同picId
     *           |- briefDesc                   不明数据
     *           |- picUrl                      艺术家图片链接
     *           |- img1v1Url                   不明数据，链接，同picUrl
     *           |- albumSize                   不明数据，专辑大小
     *           |- alias                       不明数据，可作为别名列表
     *           |- trans                       不明数据
     *           |- tns                         不明数据
     *           |- musicSize                   不明数据
     *           |- userId                      用户ID，网易音乐人ID
     *        |- album                          album列，一个键值列表，其中包含专辑的信息
     *           |- id                          专辑ID
     *           |- name                        专辑名字
     *           |- picId                       专辑图片ID
     *           |- picUrl                      专辑图片链接
     *           |- alias                       不明数据，可作为别名列表
     *           |- transNames                  别名
     *           |- type                        类型，一般值为 "专辑"
     *           |- size                        专辑曲目数量
     *           |- blurPicUrl                  模糊图片链接，一般值同picUrl
     *           |- companyId                   专辑发布公司ID
     *           |- pic                         图片，一个数字，同picId
     *           |- publishTime                 发布日期（此项值需要转换，示例值：1490716800000）
     *           |- description                 专辑简介，这个值在客户端无法获取
     *           |- tags                        标签
     *           |- company                     专辑发行公司
     *           |- breifDesc                   不明数据
     *           |- artist                      专辑艺术家
     *              |- name                     （初始化值）艺术家名字
     *              |- id                       （初始化值）艺术家ID
     *              |- picId                    （初始化值）艺术家图片ID
     *              |- img1v1Id                 （初始化值）不明数据
     *              |- briefDesc                （初始化值）不明数据
     *              |- picUrl                   艺术家图片链接
     *              |- img1v1Url                不明数据，一般值同picUrl
     *              |- albumSize                （初始化值）不明数据，专辑大小
     *              |- alias                    （初始化值）不明数据，可作为别名列表
     *              |- trans                    （初始化值）不明数据
     *              |- tns                      （初始化值）不明数据
     *              |- musicSize                （初始化值）不明数据
     *           |- songs                       数组
     *        |- commentThreadId                评论区ID，字符串
     *        |- mvid                           MV的ID，数字
     *        |- cd                             专辑碟号，该曲目所在的专辑单碟编号，数字
     *        |- starred                        喜欢的判定值，判定用户是否喜欢过该曲目
     *        |- popularity                     热度，数字
     *        |- score                          分数，数字
     *        |- starredNum                     不明数据，喜欢的数目
     *        |- duration                       曲目长度
     *        |- playedNum                      播放次数
     *        |- ringtone                       不明数据，客户端均衡器用
     *        |- rtUrl                          不明数据
     *        |- rtUrls                         不明数据，数组
     *        |- pstatus                        不明数据
     *        |- fee                            费用，数字
     *        |- version                        版本号，曲目信息版本
     *        |- songType                       曲目类型
     *        |- mst                            不明数据
     *        |- ftype                          不明数据
     *        |- yunSong                        不明数据
     *        |- mp3Url                         MP3文件链接
     *        |- reason                         推荐原因，不同于recommendReason，这个仅在每日推荐列表播放下可见
     *        |- bMusic                         不明数据，一个键值列表，未知品质
     *           |- name                        名字
     *           |- id                          品质ID
     *           |- size                        文件大小
     *           |- extension                   文件扩展名
     *           |- sr                          采样率
     *           |- playTime                    长度
     *           |- dfsId_str                   不明数据
     *           |- bitrate                     比特率，此品质未知
     *           |- dfsId                       不明数据，数字
     *           |- size                        文件大小，字节作为单位，byte，数字
     *           |- volumeDelta                 音量Delta值，浮点型
     *        |- hMusic                         高品质音乐，一个键值列表
     *           |- name                        名字
     *           |- id                          品质ID
     *           |- size                        文件大小
     *           |- extension                   文件扩展名
     *           |- sr                          采样率
     *           |- playTime                    长度
     *           |- dfsId_str                   不明数据
     *           |- bitrate                     比特率，高品质为320000
     *           |- dfsId                       不明数据，数字
     *           |- size                        文件大小，字节作为单位，byte，数字
     *           |- volumeDelta                 音量Delta值，浮点型
     *        |- mMusic                         中品质音乐，一个键值列表
     *           |- name                        名字
     *           |- id                          品质ID
     *           |- size                        文件大小
     *           |- extension                   文件扩展名
     *           |- sr                          采样率
     *           |- playTime                    长度
     *           |- dfsId_str                   不明数据
     *           |- bitrate                     比特率，中品质为160000
     *           |- dfsId                       不明数据，数字
     *           |- size                        文件大小，字节作为单位，byte，数字
     *           |- volumeDelta                 音量Delta值，浮点型
     *        |- lMusic                         低品质音乐，一个键值列表
     *           |- name                        名字
     *           |- id                          品质ID
     *           |- size                        文件大小
     *           |- extension                   文件扩展名
     *           |- sr                          采样率
     *           |- playTime                    长度
     *           |- dfsId_str                   不明数据
     *           |- bitrate                     比特率，低品质为96000
     *           |- dfsId                       不明数据，数字
     *           |- size                        文件大小，字节作为单位，byte，数字
     *           |- volumeDelta                 音量Delta值，浮点型   
     *        |- privilege                      权限
     *           |- id                          ID值，同曲目ID
     *           |- version                     版本号，测试时获得的值是：0-0-0-999-999-999-320-7-1-1-0
     *           |- fee                         费用，数字
     *           |- payed                       已支付次数，数字
     *           |- status                      不明数据
     *           |- maxPlayBr                   最大的可播放比特率
     *           |- maxDownBr                   最大的可下载比特率
     *           |- maxSongBr                   最大的曲目比特率
     *           |- maxFreeBr                   最大的免费比特率
     *           |- sharePriv                   分享权限，数字
     *           |- commentPriv                 评论权限，数字
     *           |- subPriv                     不明数据，子权限，数字
     *           |- cloudSong                   不明数据，云音乐，数字
     *           |- toast                       不明数据，此处测试时为false
     *        |- copyFrom                       不明数据，字符串
     *        |- audition                       不明数据，空值
     *        |- rtype                          不明数据，数字
     *        |- rurl                           不明数据，空值
     *        |- recommendReason                推荐原因，字符串
     *        |- alg                            不明数据
     *        |- commentCount                   评论数统计，数字
     *        |- copyright                      不明数据，版权，数字
     *        |- lrcAbstractEnd                 不明数据，歌词抽象结束
     *        |- lrcAbstractStart               不明数据，歌词抽象开始
     *        |- indexId                        不明数据，索引ID，数字
     *        |- haslyric                       是否有歌词的判定值，判定是否有歌词
     *     |- tid                               不明数据，同id
     *     |- radio                             电台，一个键值列表，不太详细的列表
     *        |- dj                             DJ的名字，此处为null
     *        |- category                       分类，字符串
     *        |- buyed                          购买的判定值，这里指的应该是订阅与否
     *        |- price                          价格，此处无效
     *        |- originalPrice                  原始价格，此处无效
     *        |- discountPrice                  打折价格，此处无效
     *        |- purchaseCount                  购买人数，数字
     *        |- lastProgramName                最后更新的节目名字
     *        |- videos                         视频，此处空值
     *        |- finished                       不明数据，结束的判断值
     *        |- underShelf                     不明数据
     *        |- picUrl                         电台图片链接
     *        |- picId                          电台图片ID
     *        |- categoryId                     分类ID
     *        |- lastProgramId                  最后更新的节目ID
     *        |- createTime                     创建时间
     *        |- feeScope                       不明数据
     *        |- programCount                   项目统计数
     *        |- subCount                       订阅人数统计
     *        |- desc                           介绍，字符串
     *        |- lastProgramCreateTime          最后更新的节目创建时间
     *        |- radioFeeType                   电台费用类型
     *        |- name                           电台名字
     *        |- id                             电台ID
     *        |- subed                          订阅的判定值
     *     |- program                           节目，一个键值列表，仅在电台条目下可用
     *        |- mainSong                       不明数据，主要曲目，一个值，示例值：411421177
     *        |- songs                          曲目数，空值
     *        |- dj                             DJ，一个键值列表，详细的电台主播信息
     *           |- defaultAvatar               默认头像的判定值
     *           |- province                    不明数据，省份
     *           |- authStatus                  认证状态，数字
     *           |- followed                    关注的判定值
     *           |- avatarUrl                   头像链接
     *           |- accountStatus               账号状态，注销账号的值为30
     *           |- gender                      性别，女性为2
     *           |- city                        不明数据，城市，数字
     *           |- birthday                    出生日期，数字
     *           |- userId                      用户ID，数字
     *           |- userType                    用户类型，数字
     *           |- nickname                    用户名，字符串
     *           |- signature                   个性签名
     *           |- description                 自我介绍
     *           |- detailDescription           详细的自我介绍
     *           |- avatarImgId                 头像图片ID，数字
     *           |- backgroundImgId             背景图片ID，数字
     *           |- backgroundUrl               背景图片链接
     *           |- authority                   不明数据，许可机构
     *           |- mutual                      不明数据，判定值
     *           |- expertTags                  用户徽章，比如音乐达人
     *           |- experts                     徽章
     *           |- djStatus                    主播状态
     *           |- vipType                     VIP类型
     *           |- remarkName                  额外名字
     *           |- avatarImgIdStr              头像图片ID，字符串
     *           |- backgroundImgIdStr          背景图片ID，字符串
     *           |- avatarImgId_str             头像图片ID，字符串
     *           |- brand                       不明数据
     *        |- blurCoverUrl                   模糊的封面链接
     *        |- radio                          电台，一个键值列表，简要的信息
     *           |- dj                          DJ的名字，字符串
     *              |- defaultAvatar            默认头像的判定值
     *              |- province                 不明数据，省份
     *              |- authStatus               认证状态，数字
     *              |- followed                 关注的判定值
     *              |- avatarUrl                头像链接
     *              |- accountStatus            账号状态，注销账号的值为30
     *              |- gender                   性别，女性为2
     *              |- city                     不明数据，城市，数字
     *              |- birthday                 出生日期，数字
     *              |- userId                   用户ID，数字
     *              |- userType                 用户类型，数字
     *              |- nickname                 用户名，字符串
     *              |- signature                个性签名
     *              |- description              自我介绍
     *              |- detailDescription        详细的自我介绍
     *              |- avatarImgId              头像图片ID，数字
     *              |- backgroundImgId          背景图片ID，数字
     *              |- backgroundUrl            背景图片链接
     *              |- authority                不明数据，许可机构
     *              |- mutual                   不明数据，判定值
     *              |- expertTags               用户徽章，比如音乐达人
     *              |- experts                  徽章
     *              |- djStatus                 主播状态
     *              |- vipType                  VIP类型
     *              |- remarkName               额外名字
     *              |- avatarImgIdStr           头像图片ID，字符串
     *              |- backgroundImgIdStr       背景图片ID，字符串
     *              |- avatarImgId_str          头像图片ID，字符串
     *              |- brand                    不明数据
     *              |- canReward                打赏的判定值
     *              |- rewardCount              打赏数目统计
     *           |- category                    分类，字符串
     *           |- buyed                       购买的判定值，这里指的应该是订阅与否
     *           |- price                       价格，此处无效
     *           |- originalPrice               原始价格，此处无效
     *           |- discountPrice               打折价格，此处无效
     *           |- purchaseCount               购买人数，数字
     *           |- lastProgramName             最后更新的节目名字
     *           |- videos                      视频，此处空值
     *           |- finished                    不明数据，结束的判断值
     *           |- underShelf                  不明数据
     *           |- picUrl                      电台图片链接
     *           |- picId                       电台图片ID
     *           |- categoryId                  分类ID
     *           |- lastProgramId               最后更新的节目ID
     *           |- createTime                  创建时间
     *           |- feeScope                    不明数据
     *           |- programCount                节目统计数
     *           |- subCount                    订阅人数统计
     *           |- desc                        介绍，字符串
     *           |- lastProgramCreateTime       最后更新的节目创建时间
     *           |- radioFeeType                电台费用类型
     *           |- name                        电台名字
     *           |- id                          电台ID
     *           |- subed                       订阅的判定值
     *           |- rcmdtext                    不明数据，空值，字符串
     *           |- newProgramCount             新的节目数目统计
     *           |- rcmdText                    不明数据，空值，字符串
     *           |- composeVideo                创作视频的判定值
     *           |- shareCount                  分享次数统计
     *           |- likedCount                  喜欢次数统计
     *           |- commentDatas                评论数据，一个键值列表
     *              |- userProfile              用户资料，一个键值列表
     *                 |- defaultAvatar         默认头像的判定值
     *                 |- province              不明数据，省份
     *                 |- authStatus            认证状态，数字
     *                 |- followed              关注的判定值
     *                 |- avatarUrl             头像链接
     *                 |- accountStatus         账号状态，注销账号的值为30
     *                 |- gender                性别，女性为2
     *                 |- city                  不明数据，城市，数字
     *                 |- birthday              出生日期，数字
     *                 |- userId                用户ID，数字
     *                 |- userType              用户类型，数字
     *                 |- nickname              用户名，字符串
     *                 |- signature             个性签名
     *                 |- description           自我介绍
     *                 |- detailDescription     详细的自我介绍
     *                 |- avatarImgId           头像图片ID，数字
     *                 |- backgroundImgId       背景图片ID，数字
     *                 |- backgroundUrl         背景图片链接
     *                 |- authority             不明数据，许可机构
     *                 |- mutual                不明数据，判定值
     *                 |- expertTags            用户徽章，比如音乐达人
     *                 |- experts               徽章
     *                 |- djStatus              主播状态
     *                 |- vipType               VIP类型
     *                 |- remarkName            额外名字
     *                 |- avatarImgIdStr        头像图片ID，字符串
     *                 |- backgroundImgIdStr    背景图片ID，字符串
     *              |- content                  评论内容
     *              |- programName              节目名称
     *              |- programId                节目ID
     *              |- commentId                评论ID
     *           |- commentCount                评论计数
     *     |- radio                             电台，一个键值列表，不太详细的列表
     *        |- dj                             DJ的名字，此处为null
     *        |- category                       分类，字符串
     *        |- buyed                          购买的判定值，这里指的应该是订阅与否
     *        |- price                          价格，此处无效
     *        |- originalPrice                  原始价格，此处无效
     *        |- discountPrice                  打折价格，此处无效
     *        |- purchaseCount                  购买人数，数字
     *        |- lastProgramName                最后更新的节目名字
     *        |- videos                         视频，此处空值
     *        |- finished                       不明数据，结束的判断值
     *        |- underShelf                     不明数据
     *        |- picUrl                         电台图片链接
     *        |- picId                          电台图片ID
     *        |- categoryId                     分类ID
     *        |- lastProgramId                  最后更新的节目ID
     *        |- createTime                     创建时间
     *        |- feeScope                       不明数据
     *        |- programCount                   项目统计数
     *        |- subCount                       订阅人数统计
     *        |- desc                           介绍，字符串
     *        |- lastProgramCreateTime          最后更新的节目创建时间
     *        |- radioFeeType                   电台费用类型
     *        |- name                           电台名字
     *        |- id                             电台ID
     *        |- subed                          订阅的判定值
     *     |- href                              来源链接，字符串，专辑链接；私人FM播放模式示例值：/m/fm/?fromSource=1
     *     |- text                              来源，多种可能性
     *     |- nickName                          来源作者，比如歌单作者
     *     |- userId                            作者ID
     *     |- startlogtime                      不明数据，数字
     *     |- loaderr                           加载错误的判定值
     *     |- playedTime                        播放次数，数字
     *     |- playType                          播放类型
     *     |- playBrt                           正在播放的比特率
     *     |- playFile                          本地文件所在位置
     *     |- lrctype                           歌词类型，online
     *     |- lrcid                             歌词ID
     *     |- qid                               不明数据，示例值：4937714_2_493807
     *     |- time                              时间，数字
     *     
     *                                              备注部分
     * 
     * href的值，在专辑播放模式下：/m/album/?id=3428149&rid=R_AL_3_3428149&fromSource=1
     *          在私人FM播放模式下：/m/fm/
     *          在歌单播放模式下：/m/playlist/?id=894355338&rid=A_PL_0_894355338&fromSource=1
     *          在电台播放模式下：/m/djradio/?id=828002&fromSource=1
     *          在每日推荐模式下：/m/dailysong/?fromSource=1
     *          在搜索页下：#/m/search/?type=1&s=Kaine%20%2F%20Salvation&fromSource=1
     *     
     * 
     ******************************************************************************************************/
    #endregion

    public class TrackArtistsItem
    {
        public string name { get; set; }

        public int id { get; set; }

        public int picId { get; set; }

        public int img1v1Id { get; set; }

        public string briefDesc { get; set; }

        public string picUrl { get; set; }

        public string img1v1Url { get; set; }

        public int albumSize { get; set; }

        public List<string> alias { get; set; }

        public string trans { get; set; }

        public int musicSize { get; set; }

        public int userId { get; set; }
    }

    public class Artist
    {
        public string name { get; set; }

        public int id { get; set; }

        public int picId { get; set; }

        public int img1v1Id { get; set; }

        public string briefDesc { get; set; }

        public string picUrl { get; set; }

        public string img1v1Url { get; set; }

        public int albumSize { get; set; }

        public List<string> alias { get; set; }

        public string trans { get; set; }

        public int musicSize { get; set; }
    }

    public class AlbumArtistsItem
    {
        public string name { get; set; }

        public int id { get; set; }

        public int picId { get; set; }

        public int img1v1Id { get; set; }

        public string briefDesc { get; set; }

        public string picUrl { get; set; }

        public string img1v1Url { get; set; }

        public int albumSize { get; set; }

        public List<string> alias { get; set; }

        public string trans { get; set; }

        public int musicSize { get; set; }
    }

    public class Album
    {
        public string name { get; set; }

        public int id { get; set; }

        public string type { get; set; }

        public int size { get; set; }

        public int picId { get; set; }

        public string blurPicUrl { get; set; }

        public int companyId { get; set; }

        public int pic { get; set; }

        public string picUrl { get; set; }

        public int publishTime { get; set; }

        public string description { get; set; }

        public string tags { get; set; }

        public string company { get; set; }

        public string briefDesc { get; set; }

        public Artist artist { get; set; }

        public List<string> songs { get; set; }

        public List<string> alias { get; set; }

        public int status { get; set; }

        public int copyrightId { get; set; }

        public string commentThreadId { get; set; }

        public List<AlbumArtistsItem> artists { get; set; }
    }

    public class HMusic
    {
        public string name { get; set; }

        public int id { get; set; }

        public int size { get; set; }

        public string extension { get; set; }

        public int sr { get; set; }

        public int dfsId { get; set; }

        public int bitrate { get; set; }

        public int playTime { get; set; }

        public int volumeDelta { get; set; }
    }

    public class MMusic
    {
        public string name { get; set; }

        public int id { get; set; }

        public int size { get; set; }

        public string extension { get; set; }

        public int sr { get; set; }

        public int dfsId { get; set; }

        public int bitrate { get; set; }

        public int playTime { get; set; }

        public int volumeDelta { get; set; }
    }

    public class LMusic
    {
        public string name { get; set; }

        public int id { get; set; }

        public int size { get; set; }

        public string extension { get; set; }

        public int sr { get; set; }

        public int dfsId { get; set; }

        public int bitrate { get; set; }

        public int playTime { get; set; }

        public int volumeDelta { get; set; }
    }

    public class BMusic
    {
        public string name { get; set; }

        public int id { get; set; }

        public int size { get; set; }

        public string extension { get; set; }

        public int sr { get; set; }

        public int dfsId { get; set; }

        public int bitrate { get; set; }

        public int playTime { get; set; }

        public int volumeDelta { get; set; }
    }

    public class Radio
    {
        public string dj { get; set; }

        public string category { get; set; }

        public string buyed { get; set; }

        public int price { get; set; }

        public int originalPrice { get; set; }

        public string discountPrice { get; set; }

        public int purchaseCount { get; set; }

        public string lastProgramName { get; set; }

        public string videos { get; set; }

        public string finished { get; set; }

        public string underShelf { get; set; }

        public string picUrl { get; set; }

        public int radioFeeType { get; set; }

        public int lastProgramCreateTime { get; set; }

        public string desc { get; set; }

        public int picId { get; set; }

        public int categoryId { get; set; }

        public int lastProgramId { get; set; }

        public int createTime { get; set; }

        public int feeScope { get; set; }

        public int programCount { get; set; }

        public int subCount { get; set; }

        public string name { get; set; }

        public int id { get; set; }

        public string subed { get; set; }
    }

    public class Dj
    {
        public string defaultAvatar { get; set; }

        public int province { get; set; }

        public int authStatus { get; set; }

        public string followed { get; set; }

        public string avatarUrl { get; set; }

        public int accountStatus { get; set; }

        public int gender { get; set; }

        public int city { get; set; }

        public int birthday { get; set; }

        public int userId { get; set; }

        public int userType { get; set; }

        public string nickname { get; set; }

        public string signature { get; set; }

        public string description { get; set; }

        public string detailDescription { get; set; }

        public int avatarImgId { get; set; }

        public int backgroundImgId { get; set; }

        public string backgroundUrl { get; set; }

        public int authority { get; set; }

        public string mutual { get; set; }

        public string expertTags { get; set; }

        public string experts { get; set; }

        public int djStatus { get; set; }

        public int vipType { get; set; }

        public string remarkName { get; set; }

        public string avatarImgIdStr { get; set; }

        public string backgroundImgIdStr { get; set; }

        public string avatarImgId_str { get; set; }

        public string brand { get; set; }
    }

    public class DjDetailed
    {
        public string defaultAvatar { get; set; }

        public int province { get; set; }

        public int authStatus { get; set; }

        public string followed { get; set; }

        public string avatarUrl { get; set; }

        public int accountStatus { get; set; }

        public int gender { get; set; }

        public int city { get; set; }

        public int birthday { get; set; }

        public int userId { get; set; }

        public int userType { get; set; }

        public string nickname { get; set; }

        public string signature { get; set; }

        public string description { get; set; }

        public string detailDescription { get; set; }

        public int avatarImgId { get; set; }

        public int backgroundImgId { get; set; }

        public string backgroundUrl { get; set; }

        public int authority { get; set; }

        public string mutual { get; set; }

        public string expertTags { get; set; }

        public string experts { get; set; }

        public int djStatus { get; set; }

        public int vipType { get; set; }

        public string remarkName { get; set; }

        public string avatarImgIdStr { get; set; }

        public string backgroundImgIdStr { get; set; }

        public string avatarImgId_str { get; set; }

        public string canReward { get; set; }

        public int rewardCount { get; set; }
    }

    public class ProgramRadio
    {
        public Dj dj { get; set; }

        public string category { get; set; }

        public string buyed { get; set; }

        public int price { get; set; }

        public int originalPrice { get; set; }

        public string discountPrice { get; set; }

        public int purchaseCount { get; set; }

        public string lastProgramName { get; set; }

        public string videos { get; set; }

        public string finished { get; set; }

        public string underShelf { get; set; }

        public int radioFeeType { get; set; }

        public int lastProgramCreateTime { get; set; }

        public string picUrl { get; set; }

        public int picId { get; set; }

        public int programCount { get; set; }

        public int subCount { get; set; }

        public int categoryId { get; set; }

        public int lastProgramId { get; set; }

        public int createTime { get; set; }

        public int feeScope { get; set; }

        public string desc { get; set; }

        public string name { get; set; }

        public int id { get; set; }

        public string rcmdtext { get; set; }

        public int newProgramCount { get; set; }

        public string rcmdText { get; set; }

        public string composeVideo { get; set; }

        public int shareCount { get; set; }

        public string subed { get; set; }

        public int likedCount { get; set; }

        public List<string> commentDatas { get; set; }

        public int commentCount { get; set; }
    }

    public class RadioProgram
    {
        public int mainSong { get; set; }

        public string songs { get; set; }

        public DjDetailed dj { get; set; }

        public string blurCoverUrl { get; set; }

        public Radio radio { get; set; }

        public int duration { get; set; }

        public string buyed { get; set; }

        public string programDesc { get; set; }

        public string h5Links { get; set; }

        public string canReward { get; set; }

        public int auditStatus { get; set; }

        public int createTime { get; set; }

        public List<string> channels { get; set; }

        public int listenerCount { get; set; }

        public int subscribedCount { get; set; }

        public string reward { get; set; }

        public int mainTrackId { get; set; }

        public string coverUrl { get; set; }

        public int programFeeType { get; set; }

        public string titbits { get; set; }

        public int feeScope { get; set; }

        public int pubStatus { get; set; }

        public int bdAuditStatus { get; set; }

        public int serialNum { get; set; }

        public string titbitImages { get; set; }

        public string isPublish { get; set; }

        public int trackCount { get; set; }

        public string commentThreadId { get; set; }

        public string description { get; set; }

        public string name { get; set; }

        public int id { get; set; }

        public int shareCount { get; set; }

        public string subscribed { get; set; }

        public int likedCount { get; set; }

        public int commentCount { get; set; }
    }

    public class Track
    {
        public string name { get; set; }

        public int id { get; set; }

        public int position { get; set; }

        public List<string> alias { get; set; }

        public int status { get; set; }

        public int fee { get; set; }

        public int copyrightId { get; set; }

        public string disc { get; set; }

        public int no { get; set; }

        public List<TrackArtistsItem> artists { get; set; }

        public Album album { get; set; }

        public string starred { get; set; }

        public int popularity { get; set; }

        public int score { get; set; }

        public int starredNum { get; set; }

        public int duration { get; set; }

        public int playedNum { get; set; }

        public int dayPlays { get; set; }

        public int hearTime { get; set; }

        public string ringtone { get; set; }

        public string crbt { get; set; }

        public string audition { get; set; }

        public string copyFrom { get; set; }

        public string commentThreadId { get; set; }

        public string rtUrl { get; set; }

        public int ftype { get; set; }

        public List<string> rtUrls { get; set; }

        public HMusic hMusic { get; set; }

        public MMusic mMusic { get; set; }

        public LMusic lMusic { get; set; }

        public BMusic bMusic { get; set; }

        public int rtype { get; set; }

        public string rurl { get; set; }

        public int mvid { get; set; }

        public string mp3Url { get; set; }

        public int programId { get; set; }

        public Radio radio { get; set; }

        public RadioProgram program { get; set; }
    }

    public class Hierarchy
    {
        public string fm { get; set; }

        public Track track { get; set; }

        public string id { get; set; }

        public int tid { get; set; }

        public int program { get; set; }

        public string fid { get; set; }

        public string data { get; set; }

        public string href { get; set; }

        public string text { get; set; }

        public string nickName { get; set; }

        public string userId { get; set; }

        public int startlogtime { get; set; }

        public string loaderr { get; set; }

        public int playedTime { get; set; }

        public int playType { get; set; }

        public int playBrt { get; set; }

        public string playFile { get; set; }

        public string qid { get; set; }

        public int time { get; set; }
    }
}
