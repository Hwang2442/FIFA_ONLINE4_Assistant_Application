# [FIFA ONLINE4] OpenAPI
- 피파온라인4 OpenAPI를 사용한 유니티 프로젝트입니다.

## Playstore and YouTube
[Playstore](https://play.google.com/store/apps/details?id=com.hwang.fifa4assistant)

[![YouTube](http://img.youtube.com/vi/SloTAaVXK2U/0.jpg)](https://youtu.be/SloTAaVXK2U?t=0s) 

## 사용한 외부 에셋
- TextMeshPro
- [DOTween](https://assetstore.unity.com/packages/tools/visual-scripting/dotween-pro-32416)
- [SCI-FI UI Pack Pro](https://assetstore.unity.com/packages/2d/gui/sci-fi-ui-pack-pro-149421)

## OpenAPI Docs
- 이용 가이드 및 API KEY 발급에 관한 내용은 [이용 가이드](https://developers.nexon.com/fifaonline4/guides)를 참고해주세요.
- **유저정보**
    - [유저 닉네임으로 유저 정보 조회](https://developers.nexon.com/fifaonline4/api/6/15)
    - [유저 고유 식별자로 역대 최고 등급 조회](https://developers.nexon.com/fifaonline4/api/6/17)
    - [유저 고유 식별자로 유저의 매치 기록 조회](https://developers.nexon.com/fifaonline4/api/6/18)
    - [유저 고유 식별자로 유저의 거래 기록 조회](https://developers.nexon.com/fifaonline4/api/6/19)
- **매치정보**
    - [매치 상세 기록 조회](https://developers.nexon.com/fifaonline4/api/7/21)
- **메타정보**
    - [매치 종류(matchtype) 메타데이터 조회](https://developers.nexon.com/fifaonline4/api/10/23)
    - [선수 고유 식별자(spid) 메타데이터 조회](https://developers.nexon.com/fifaonline4/api/10/24)
    - [시즌아이디(seasonId) 메타데이터 조회](https://developers.nexon.com/fifaonline4/api/10/25)
    - [등급 식별자(division) 메타데이터 조회](https://developers.nexon.com/fifaonline4/api/10/27)
    - [볼타 공식경기 등급 식별자 메타데이터 조회](https://developers.nexon.com/fifaonline4/api/10/41)
    - [선수 고유 식별자(spid)로 선수 액션샷 이미지 조회](https://developers.nexon.com/fifaonline4/api/10/28)
    - [선수 식별자(pid)로 선수 액션샷 이미지 조회](https://developers.nexon.com/fifaonline4/api/10/29)
    - [선수 고유 식별자(spid)로 선수 이미지 조회](https://developers.nexon.com/fifaonline4/api/10/30)
    - [선수 식별자(pid)로 선수 이미지 조회](https://developers.nexon.com/fifaonline4/api/10/31)

## 발급받은 API KEY 적용
- 'KeyToken'스크립트 생성 후 아래와 같이 작성.
``` c#
namespace FIFA4
{
    public static class KeyToken
    {
        private static readonly string m_key = "my key";

        public static string Key => m_key;
    }
}
```


