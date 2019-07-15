import axios, { AxiosInstance } from 'axios'
import { CityDto } from './dto/CityDto';

class RestApiClient {

    private backend: AxiosInstance = this.createAxios()
    
    public async searchCities(searchText: string) : Promise<CityDto[]> {
        const response = await this.backend.get(`/api/cities/search?q=${searchText}`);
        // tslint:disable-next-line: no-console
        console.table(response.data)
        return response.data
    }

    public async getFavoriteCities() : Promise<CityDto[]> {
        const response = await this.backend.get(`/api/cities/favorite`);
        // tslint:disable-next-line: no-console
        console.table(response.data);
        return response.data;
    }

    public async updateCity(city: CityDto) : Promise<any> {
       return await this.backend.put(`/api/cities/${city.id}`, city);
    } 

    private createAxios(): AxiosInstance {
		const instance = axios.create({
            baseURL: "http://localhost:5000",
			headers: { "Content-Type": "text/json" },            
			timeout: 5000,
		})

		return instance
    }
}

const RestClient = new RestApiClient()
export default RestClient
