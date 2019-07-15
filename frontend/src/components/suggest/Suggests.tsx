import * as React from 'react';
import { CityDto } from 'src/api/dto/CityDto';
import './Styles.css';

interface IProps {
    cities: CityDto[]
    cityUpdated: (value: CityDto) => void;
}

class Suggests extends React.Component<IProps> {
    public render() {
        return (
            <ul className="suggests-ul">
                {this.props.cities.map(r =>
                    <li className="suggests-li" key={r.id}>
                        {r.name}
                        <span className="fill-space" />
                        <input key={r.id} type="checkbox" defaultChecked={r.isFavorite} 
                            onChange={this.isFavoriteChanged.bind(this, r.id)} />
                    </li>)}
            </ul>
        );
    }

    private isFavoriteChanged = (id: string, e: React.ChangeEvent<HTMLInputElement>) => {
        const city = this.props.cities.find(x => x.id === id)
        if (city) {
            city.isFavorite = e.target.checked;
            this.props.cityUpdated(city);
        }
    }
}

export default Suggests;