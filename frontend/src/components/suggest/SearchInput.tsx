import { debounce } from 'lodash';
import * as React from 'react';
import { CityDto } from 'src/api/dto/CityDto';
import RestClient from 'src/api/RestClient';
import FavoriteList from './FavoriteList';
import './Styles.css';
import Suggests from './Suggests';


interface IState {
    query: string;
    cities: CityDto[],
    favoriteCities: CityDto[]
}

const initialState = {
    cities: [],
    favoriteCities : [],
    query: ''
}

class SearchInput extends React.Component<{}, IState>{
    public readonly state: IState = initialState
   
    private loadCities = debounce(async () => {
        const cities = await RestClient.searchCities(this.state.query)
        this.setState({
            ...this.state,
            cities
        })
    }, 500);

    public componentDidMount() {
        RestClient.getFavoriteCities().then(favoriteCities => {
            this.setState({
                ...this.state,
                favoriteCities
            })
        })
    }

    public render() {
        return (
            <div className="container">
                <div>
                    <label>Search</label>
                    <div className="drop-down">
                        <input className="input-control" type="search" value={this.state.query} onChange={this.handleQuery} />
                        {this.state.cities.length > 0 
                            ? <Suggests 
                                cityUpdated={this.favoriteCityChanged}
                                cities={this.state.cities} /> 
                            : <div />}
                    </div>
                </div>
                <div>
                    <label>Favorite cities</label>
                    <FavoriteList favoriteCities={this.state.favoriteCities}/>
                </div>
            </div>
        );
    }

    private handleQuery = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.setState({
            query: e.target.value
        }, () => this.loadCities());
    };

    private favoriteCityChanged = async (city: CityDto) => {
        await RestClient.updateCity(city);
        const favoriteCities = await RestClient.getFavoriteCities();
        this.setState({
            ...this.state,
            favoriteCities
        })
    }
}

export default SearchInput;