using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Services;

namespace EpicBackport.Utilities;

[Injectable(typePriority: OnLoadOrder.PostDBModLoader + 3)]
public class BaseGameItemEdits(
    ISptLogger<BaseGameItemEdits> logger,
    DatabaseService databaseService
):IOnLoad
{
    public Task OnLoad()
    {
        EditFilters();
        return Task.CompletedTask;
    }

    private void EditFilters()
    {
        var dbItems = databaseService.GetItems();
        foreach (var (id, item) in dbItems)
        {
            switch (id)
            {
                case "5447a9cd4bdc2dbd208b4567":
                    ModifySlotFilters(item, 2, 0, [
                        "5bb20d53d4351e4502010a69"]);
                    break; //Pushing HK Upper to M4A1
                
                case "5bb2475ed4351e00853264e3":
                    ModifySlotFilters(item, 2, 0, [
                        "5c0e2f26d174af02a9625114",
                        "55d355e64bdc2d962f8b4569",
                        "5d4405aaa4b9361e6a4e6bd3",
                        "5c07a8770db8340023300450",
                        "59bfe68886f7746004266202",
                        "63f5ed14534b2c3d5479a677",
                        "c6aa3fe86a9fc7ea6c220c2f",
                        "cc85761fc4963442077f9460"]); //Pushing M4 uppers to HK416
                    
                    ModifySlotFilters(item, 3, 0, [
                        "5a33ca0fc4a282000d72292f",
                        "5c0faeddd174af02a962601f",
                        "5649be884bdc2d79388b4577",
                        "5d120a10d7ad1a4e1026ba85",
                        "602e3f1254072b51b239f713",
                        "5c793fb92e221644f31bfb64",
                        "5c793fc42e221600114ca25d",
                        "638de3603a1a4031d8260b8c"]); //Push all AR stocks to HK416
                    break;
                
                
                
                case "65266fd43341ed9aa903dd56":
                    ModifySlotFilters(item, 0, 0, [
                        "5e208b9842457a4a7a33d074",
                        "5cc125555c98bf150a4fd068"]);
                    break; //Pushing DTKP suppressor and Wolverine to RPD barrels
                
                case "6513eff1e06849f06c0957d4":
                    ModifySlotFilters(item, 1, 0, [
                        "5e208b9842457a4a7a33d074",
                        "5cc125555c98bf150a4fd068"]);
                    break; //Pushing DTKP suppressor and Wolverine to RPD barrels
                
                case "5c7e5f112e221600106f4ede":
                    ModifySlotFilters(item, 0, 0, [
                        "40c62378fa93a829532ecc5e",
                        "6d9f22a75064ebb92b3ece1c"]);
                    break; //Push M4-2k to 5.56 51T flash hider
                
                case "5d25a6538abbc306c62e630d":
                    ModifySlotFilters(item, 0, 0, [
                        "6529243824cbe3c74a05e5c1",
                        "6529302b8c26af6326029fb7"], true);
                    break; //Push 6.8x51 to M700 mags
                
                case "5d25a4a98abbc30b917421a4":
                    ModifySlotFilters(item, 0, 0, [
                        "6529243824cbe3c74a05e5c1",
                        "6529302b8c26af6326029fb7"], true);
                    break; //Push 6.8x51 to M700 mags
                
                case "5d25a7b88abbc3054f3e60bc":
                    ModifySlotFilters(item, 0, 0, [
                        "6529243824cbe3c74a05e5c1",
                        "6529302b8c26af6326029fb7"], true);
                    break; //Push 6.8x51 to M700 mags
                
                case "5ce69cbad7f00c00b61c5098":
                    ModifySlotFilters(item, 0, 0, [
                        "6529243824cbe3c74a05e5c1",
                        "6529302b8c26af6326029fb7"], true);
                    break; //Push 6.8x51 to M700 mags
                
                case "5d25a6a48abbc306c62e6310":
                    ModifySlotFilters(item, 0, 0, [
                        "6529243824cbe3c74a05e5c1",
                        "6529302b8c26af6326029fb7"], true);
                    break; //Push 6.8x51 to M700 mags
                
                case "5d25af8f8abbc3055079fec5":
                    ModifySlotFilters(item, 0, 0, [
                        "6529243824cbe3c74a05e5c1",
                        "6529302b8c26af6326029fb7"], true);
                    break; //Push 6.8x51 to M700 mags
                
                case "5cf12a15d7f00c05464b293f":
                    ModifySlotFilters(item, 0, 0, [
                        "6529243824cbe3c74a05e5c1",
                        "6529302b8c26af6326029fb7"], true);
                    break; //Push 6.8x51 to M700 mags
                
                case "5bfeaa0f0db834001b734927":
                    ModifySlotFilters(item, 0, 0, [
                        "6529243824cbe3c74a05e5c1",
                        "6529302b8c26af6326029fb7"], true);
                    break; //Push 6.8x51 to M700 mags
                
                case "5bfea7ad0db834001c38f1ee":
                    ModifySlotFilters(item, 0, 0, [
                        "6529243824cbe3c74a05e5c1",
                        "6529302b8c26af6326029fb7"], true);
                    break; //Push 6.8x51 to M700 mags
                
                case "59984ab886f7743e98271174":
                    ModifySlotFilters(item, 1, 0, [
                        "6761779c48fa5c377e06fc3f",
                        "9d387502b50d1f4b0fb8b0ce"]);
                    break; //Push AK-12 stock and SAG buffer tube to vityaz
                
                case "59f9cabd86f7743a10721f46":
                    ModifySlotFilters(item, 1, 0, [
                        "6761779c48fa5c377e06fc3f",
                        "9d387502b50d1f4b0fb8b0ce"]);
                    break; //Push AK-12 stock and SAG buffer tube to saiga 9
                
                case "5ab8e9fcd8ce870019439434":
                    ModifySlotFilters(item, 6, 0, [
                        "6761779c48fa5c377e06fc3f",
                        "9d387502b50d1f4b0fb8b0ce"]); //Push AK-12 stock and SAG buffer tube to AKS74N
                    
                    ModifySlotFilters(item, 2, 0, [
                        "5cc125555c98bf150a4fd068"]); //Push Wolverine to AKS74N
                    break; 
                
                case "57dc2fa62459775949412633":
                    ModifySlotFilters(item, 1, 0, [
                        "6761779c48fa5c377e06fc3f",
                        "9d387502b50d1f4b0fb8b0ce"]); //Push AK-12 stock and SAG buffer tube to AKS-74U
                    
                    ModifySlotFilters(item, 4, 0, [
                        "5cc125555c98bf150a4fd068"]); //Push Wolverine to AKS74U
                    break; 
                
                case "583990e32459771419544dd2":
                    ModifySlotFilters(item, 1, 0, [
                        "6761779c48fa5c377e06fc3f",
                        "9d387502b50d1f4b0fb8b0ce"]); //Push AK-12 stock and SAG buffer tube to AKS-74UN
                    
                    ModifySlotFilters(item, 4, 0, [
                        "5cc125555c98bf150a4fd068"]); //Push Wolverine to AKS74UN
                    break;
                
                case "5839a40f24597726f856b511":
                    ModifySlotFilters(item, 1, 0, [
                        "6761779c48fa5c377e06fc3f",
                        "9d387502b50d1f4b0fb8b0ce"]); //Push AK-12 stock and SAG buffer tube to AKS-74UB
                    
                    ModifySlotFilters(item, 4, 0, [
                        "5cc125555c98bf150a4fd068"]); //Push Wolverine to AKS74UB
                    break;
                
                case "5bf3e0490db83400196199af":
                    ModifySlotFilters(item, 6, 0, [
                        "6761779c48fa5c377e06fc3f",
                        "9d387502b50d1f4b0fb8b0ce"]); //Push AK-12 stock and SAG buffer tube to AKS-74
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]); //Push Wolverine to AKS74
                    break;
                
                case "618b9682a3884f56c957ca78":
                    ModifySlotFilters(item, 0, 0, [
                        "81ee14e532991b2b9993ae0e",
                        "ac738256c846acc25b183a80",
                        "26f02172906cbaa1ae78e57d",
                        "87690b1fadc788a959d42e46"]);
                    break; //Push new RMR Risers to 30mm Geissele ROF mounts
                
                case "618ba92152ecee1505530bd3":
                    ModifySlotFilters(item, 0, 0, [
                        "81ee14e532991b2b9993ae0e",
                        "ac738256c846acc25b183a80",
                        "26f02172906cbaa1ae78e57d",
                        "87690b1fadc788a959d42e46"]);
                    break; //Push new RMR Risers to 30mm Geissele ROF mounts
                
                case "5580223e4bdc2d1c128b457f":
                    ModifySlotFilters(item, 0, 0, [
                        "64748d02d1c009260702b526"]);
                    break; //Push swan-off barrel to full size DB shotgun
                
                case "55d3632e4bdc2d972f8b4569":
                    ModifySlotFilters(item, 0, 0, [
                        "45b07217916365a3171c079e"]); //Push AE M4 suppressor to only AR 14.5 barrel
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]); //Push Wolverine to AR 14.5 barrel
                    break;
                
                case "55d35ee94bdc2d61338b4568":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AR 10.3 barrel
                
                case "5d440b9fa4b93601354d480c":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068",
                        "ac14dc7aa887301d799e3b2b"]);
                    break; //Push Wolverine and AEM brake to AR 20" barrel
                
                case "5d440b93a4b9364276578d4b":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068",
                        "ac14dc7aa887301d799e3b2b"]);
                    break; //Push Wolverine and AEM brake to AR 18" barrel
                
                case "5c0e2f94d174af029f650d56":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068",
                        "ac14dc7aa887301d799e3b2b"]);
                    break; //Push Wolverine and AEM brake to Molot 16 inch barrel
                
                case "63d3ce0446bd475bcb50f55f":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to BA Hansen 13.7
                
                case "63d3d44a2a49307baf09386d":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068",
                        "ac14dc7aa887301d799e3b2b"]);
                    break; //Push Wolverine and AEM brake to BA Hansen 16
                
                case "5cf67cadd7f00c065a5abab7":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to SKS WT adapter
                
                case "5f2aa43ba9b91d26f20ae6d2":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to RFB Thread spacer
                
                case "628b9c37a733087d0d7fe84b":
                    ModifySlotFilters(item, 1, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AK 545 short
                
                case "628b5638ad252a16da6dd245":
                    ModifySlotFilters(item, 1, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AK 545
                
                case "5bf3e03b0db834001d2c4a9c":
                    ModifySlotFilters(item, 2, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AK74
                
                case "5ac4cd105acfc40016339859":
                    ModifySlotFilters(item, 2, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AK74M
                
                case "5644bd2b4bdc2d3b4c8b4572":
                    ModifySlotFilters(item, 2, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AK74N
                
                case "5ac66cb05acfc40198510a10":
                    ModifySlotFilters(item, 2, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AK101
                
                case "5ac66d015acfc400180ae6e4":
                    ModifySlotFilters(item, 2, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AK102
                
                case "5ac66d2e5acfc43b321d4b53":
                    ModifySlotFilters(item, 2, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AK103
                
                case "5ac66d725acfc43b321d4b60":
                    ModifySlotFilters(item, 2, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AK104
                
                case "5ac66d9b5acfc4001633997a":
                    ModifySlotFilters(item, 2, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AK105
                
                case "62e7c7f3c34ea971710c32fc":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AUG A1 20 inch
                
                case "630e39c3bd357927e4007c15":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AUG A3 16 inch
                
                case "6333f05d1bc0e6217a0e9d34":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to AUG A1 16 inch
                
                case "5c48a2852e221602b21d5923":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to MDR 556 Barrel
                
                case "5dcbe9431e1f4616d354987e":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to MDR 762 Barrel
                
                case "622b379bf9cfc87d675d2de5":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to G36 228mm
                
                case "622b3858034a3e17ad0b81f5":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to G36 318mm
                
                case "622b38c56762c718e457e246":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to G36 480mm
                
                case "61702be9faa1272e431522c3":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to 417 16.5 barrel
                
                case "5bb20d92d4351e00853263eb":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to 416 11 inch
                
                case "5bb20d9cd4351e00334c9d8a":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to 416 14.5
                
                case "5bb20da5d4351e0035629dbf":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to 416 16.5
                
                case "5bb20dadd4351e00367faeff":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to 416 20 inch
                
                case "5c6d85e02e22165df16b81f4":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to 416 10.5
                
                case "5fbbfabed5cb881a7363194e":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to MCX 171mm
                
                case "5fbbfacda56d053a3543f799":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to MCX 229mm
                
                case "60658776f2cb2e02a42ace2b":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to MK47 254mm
                
                case "6065878ac9cf8012264142fd":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to MK47 409mm
                
                case "628a60ae6b1d481ff772e9c8":
                    ModifySlotFilters(item, 1, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to RD704
                
                case "5b099a765acfc47a8607efe3":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to SA58 11 inch
                
                case "5b7be1125acfc4001876c0e5":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to SA58 16 inch
                
                case "5b7be1265acfc400161d0798":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to SA58 21 inch
                
                case "618168b350224f204c1da4d8":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to SCAR 762 13 inch
                
                case "6183b0711cb55961fa0fdcad":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to SCAR 762 16 inch
                
                case "6183b084a112697a4b3a6e6c":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to SCAR 762 20 inch
                
                case "6183fc15d3a39d50044c13e9":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to SCAR 556 10 inch
                
                case "6183fd911cb55961fa0fdce9":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to SCAR 556 14 inch
                
                case "6183fd9e8004cc50514c358f":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to SCAR 556 18 inch
                
                case "5bfebc320db8340019668d79":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to M700 20 inch
                
                case "5d2703038abbc3105103d94c":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to M700 20 inch ST
                
                case "5cf79389d7f00c10941a0c4d":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to Mosin Kiba AKM adapter
                
                case "5cf67a1bd7f00c06585fb6f3":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to Mosin WT AK103 Adapter
                
                case "5cf79599d7f00c10875d9212":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to Mosin TR x51 adapter
                
                case "5ab3afb2d8ce87001660304d":
                    ModifySlotFilters(item, 1, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to M1A Threaded GB
                
                case "5a34f7f1c4a2826c6e06d75d":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to RSASS 18 inch
                
                case "5a34fae7c4a2826c6e06d760":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to RSASS 22 inch
                
                case "5df917564a9f347bc92edca3":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to SR25 16 inch
                
                case "5dfa397fb11454561e39246c":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to SR25 20 inch
                
                case "660126f7c752a02bbe05e688":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to M60E4 458mm
                
                case "66012788c752a02bbe05e68e":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to M60E4 475mm
                
                case "6601279cc752a02bbe05e692":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to M60E3 584mm
                
                case "66225d88a1c7e3b81600c76f":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to M60E6 458mm
                
                case "5beec1bd0db834001e6006f3":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to RPK16 15 inch
                
                case "5beec2820db834001b095426":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068"]);
                    break; //Push Wolverine to RPK16 22 inch
                
                case "652910565ae2ae97b80fdf35":
                    ModifySlotFilters(item, 0, 0, [
                        "5cc125555c98bf150a4fd068",
                        "612e0d3767085e45ef14057f",
                        "5b7d693d5acfc43bca706a3d",
                        "5a34fd2bc4a282329a73b4c5",
                        "6065c6e7132d4d12c81fd8e1",
                        "5d1f819086f7744b355c219b",
                        "5dcbe965e4ed22586443a79d",
                        "5d026791d7ad1a04a067ea63",
                        "5dfa3cd1b33c0951220c079b",
                        "6130c43c67085e45ef1405a1",
                        "5cdd7685d7f00c000f260ed2",
                        "5c878e9d2e2216000f201903",
                        "5d02677ad7ad1a04a15c0f95",
                        "5bbdb8bdd4351e4502011460",
                        "5cdd7693d7f00c0010373aa5",
                        "607ffb988900dc2d9a55b6e4",
                        "615d8eb350224f204c1da1cf",
                        "612e0e3c290d254f5e6b291d",
                        "5d443f8fa4b93678dd4a01aa",
                        "5c7954d52e221600106f4cc7",
                        "5fbc22ccf24b94483f726483",
                        "59bffc1f86f77435b128b872",
                        "5cf78496d7f00c065703d6ca",
                        "5d270ca28abbc31ee25ee821",
                        "5d270b3c8abbc3105335cfb8",
                        "5fbe7618d6fa9c00c571bb6c",
                        "628a66b41d5e41750e314f34",
                        "618178aa1cb55961fa0fdc80",
                        "6642f63667f5cb56a00662eb"]);
                    break; //Push Wolverine to SPEAR 330mm 6.8x51 barrel
                
                case "57ac965c24597706be5f975c":
                    ModifySlotFilters(item, 0, 0, [
                        "eeb62fba336b644c26813276"]);
                    break; //Push RMR mount to black elcan
                
                case "57aca93d2459771f2c7e26db":
                    ModifySlotFilters(item, 0, 0, [
                        "eeb62fba336b644c26813276"]);
                    break; //Push RMR mount to FDE elcan
                
                case "5c0e2f26d174af02a9625114":
                    ReplaceSlotFilters(item, 3, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "55d355e64bdc2d962f8b4569":
                    ReplaceSlotFilters(item, 3, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "5d4405aaa4b9361e6a4e6bd3":
                    ReplaceSlotFilters(item, 3, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "5c07a8770db8340023300450":
                    ReplaceSlotFilters(item, 3, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "59bfe68886f7746004266202":
                    ReplaceSlotFilters(item, 3, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "63f5ed14534b2c3d5479a677":
                    ReplaceSlotFilters(item, 3, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "6529119424cbe3c74a05e5bb":
                    ReplaceSlotFilters(item, 3, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "5bb20d53d4351e4502010a69":
                    ReplaceSlotFilters(item, 3, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "5c488a752e221602b412af63":
                    ReplaceSlotFilters(item, 5, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 4, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "5dcbd56fdbd3d91b3e5468d5":
                    ReplaceSlotFilters(item, 5, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 4, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "5df8e4080b92095fd441e594":
                    ReplaceSlotFilters(item, 3, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "5fc278107283c4046c581489":
                    ReplaceSlotFilters(item, 3, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "602e63fb6335467b0c5ac94d":
                    ReplaceSlotFilters(item, 3, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "606587a88900dc2d9a55b659":
                    ReplaceSlotFilters(item, 3, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "6165adcdd3a39d50044c120f":
                    ReplaceSlotFilters(item, 2, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "6165aeedfaa1272e431521e3":
                    ReplaceSlotFilters(item, 2, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "61713a8fd92c473c770214a4":
                    ReplaceSlotFilters(item, 3, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "618405198004cc50514c3594":
                    ReplaceSlotFilters(item, 2, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "618426d96c780c1e710c9b9f":
                    ReplaceSlotFilters(item, 2, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "62811fbf09427b40ab14e767":
                    ReplaceSlotFilters(item, 2, 0, [
                        "5bb20e49d4351e3bac1212de",
                        "5ba26b17d4351e00367f9bdd",
                        "5dfa3d7ac41b2312ea33362a",
                        "5c1780312e221602b66cc189",
                        "5fb6564947ce63734e3fa1da",
                        "5bc09a18d4351e003562b68e",
                        "5c18b9192e2216398b5a8104",
                        "5fc0fa957283c4046c58147e",
                        "5894a81786f77427140b8347",
                        "55d5f46a4bdc2d1b198b4567"]);
                    
                    ModifySlotFilters(item, 0, 0, [
                        "5ae30bad5acfc400185c2dc4"]);
                    break; //Change filters for AR15 rear sights
                
                case "5ae30bad5acfc400185c2dc4":
                    ModifySlotFilters(item, 0, 0, [
                        "66713838ca123f9df8e7584e",
                        "23878a19adddf4afbbcc0537"]); //Push Carry handle mounts to carry handle
                    
                    item.Properties!.Prefab!.Path = "assets/content/items/mods/sights_rear/sight_rear_ar15_colt_carry_hande_std.bundle";
                    //Change Carry handle prefab path
                    
                    item.Parent = "55818ad54bdc2ddc698b4569"; //Change carry handle parent
                    
                    item.Properties.ConflictingItems = 
                    ["61817865d3a39d50044c13a4",
                    "5bb20e49d4351e3bac1212de",
                    "5ba26b17d4351e00367f9bdd",
                    "5dfa3d7ac41b2312ea33362a",
                    "5c1780312e221602b66cc189",
                    "5fb6564947ce63734e3fa1da",
                    "5bc09a18d4351e003562b68e",
                    "5c18b9192e2216398b5a8104",
                    "5fc0fa957283c4046c58147e",
                    "5894a81786f77427140b8347",
                    "55d5f46a4bdc2d1b198b4567",
                    "e8d92f66b5cf4553048c5f5b"
                    ]; //Change carry conflicting items
                    break;
                
                case "55d5f46a4bdc2d1b198b4567":
                    item.Parent = "55818ad54bdc2ddc698b4569";
                    break; //Change A2 rear sight parent
                
                case "5bfd4c980db834001b73449d":
                    item.Parent = "55818ad54bdc2ddc698b4569";
                    break; //Change mosin carbine sight parent
                
                case "5ae099925acfc4001a5fc7b3":
                    item.Parent = "55818ad54bdc2ddc698b4569";
                    break; //Change mosin rifle sight parent
                
                case "59d650cf86f7741b846413a4":
                    item.Parent = "55818ad54bdc2ddc698b4569";
                    break; //Change akm rear sight parent
                
                case "5a0eb980fcdbcb001a3b00a6":
                    item.Parent = "55818ad54bdc2ddc698b4569";
                    break; //Change akmb rear sight parent
                
                case "628a7b23b0f75035732dd565":
                    item.Parent = "55818ad54bdc2ddc698b4569";
                    break; //Change RD704 enhanced rear sight parent
                
                case "5ac733a45acfc400192630e2":
                    item.Parent = "55818ad54bdc2ddc698b4569";
                    break; //Change AK105 rear sight parent
                
                case "5649b0544bdc2d1b2b8b458a":
                    item.Parent = "55818ad54bdc2ddc698b4569";
                    break; //Change AK74 rear sight parent
                
                case "5ac72e475acfc400180ae6fe":
                    item.Parent = "55818ad54bdc2ddc698b4569";
                    break; //Change AK74M rear sight parent
                
                case "649ec2cec93611967b03495e":
                    item.Parent = "55818ad54bdc2ddc698b4569";
                    break; //Change AK12 rear sight parent
                
                case "5bf3f59f0db834001a6fa060":
                    item.Parent = "55818ad54bdc2ddc698b4569";
                    break; //Change RPK16 rear sight parent
                
                case "651450ce0e00edc794068371":
                    item.Properties!.BFirerate = 750;
                    break; //Change SR3M firerate to match sounds
                
                case "615d8d878004cc50514c3233":
                    item.Properties!.ConflictingItems = [];
                    break; //Clear conflicting items on B&T ACRO NAR mount
            }
        }
    }
    
    private void ReplaceSlotFilters(TemplateItem item, int slotIndex, int filterIndex, HashSet<MongoId> ids)
    {
        var slot = GetSlotAtIndex(item, slotIndex);
        var filter = GetSlotFilterAtIndex(slot, filterIndex);

        filter.Filter = ids;
    }

    private void ModifySlotFilters(TemplateItem item, int slotIndex, int filterIndex, List<MongoId> ids, bool isCartridge = false)
    {
        var slot = GetSlotAtIndex(item, slotIndex, isCartridge);
        var filter = GetSlotFilterAtIndex(slot, filterIndex);

        filter.Filter!.UnionWith(ids);
    }
    
    private Slot GetSlotAtIndex(TemplateItem item, int index, bool isCartridge = false)
    {
        var slots = isCartridge ? item.Properties?.Cartridges?.ToArray() : item.Properties?.Slots?.ToArray();

        if (index >= 0 && index < slots?.Length)
        {
            return slots[index];
        }

        throw new IndexOutOfRangeException($"Index on item slot property `{item.Name}` is out of range");
    }

    private SlotFilter GetSlotFilterAtIndex(Slot slot, int index)
    {  
        var slotFilter = slot.Properties?.Filters?.ToArray() ?? [];

        if (index >= 0 && index < slotFilter.Length)
        {
            return slotFilter[index];
        }

        throw new IndexOutOfRangeException($"Index on slot property `{slot.Name}` is out of range");
    }
}