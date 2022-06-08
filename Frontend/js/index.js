const url = "https://windrestapi20220608211201.azurewebsites.net/api/Wind"

Vue.createApp({
    data(){
        return{
            windDatas: [],
            newWind: {"direction":"","speed":null,"id":0},
            speedFilter: null,
            jsSpeedFilter: 0,
            jsWindDatas:[]
        }
    },
    async created(){
        await this.getAllWind()
        this.filterJS()
    },
    methods: {

        async helperGetAndShow(url){
            try{
                const response = await axios.get(url)
                this.windDatas = await response.data
            } catch (ex){
                alert(ex.message)
            }
        },

        async getAllWind(filter){
            let newUrl = url
            if(filter != null){
                newUrl = newUrl + "?filter=" + filter
            }
            await this.helperGetAndShow(newUrl)
        },

        async addWind(){
            try{
                const response = await axios.post(url, this.newWind)
                this.getAllWind()
            } catch (ex){
                alert(ex.message)
            }
        },

       
        filterJS(){
            console.log(this.windDatas)
            this.jsWindDatas = this.windDatas.slice()
            this.jsWindDatas = this.jsWindDatas.filter(w => w.speed > this.jsSpeedFilter)
        }

    }
}).mount('#app')    