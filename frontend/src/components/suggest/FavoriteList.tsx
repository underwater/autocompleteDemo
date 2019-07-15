import * as React from 'react';
import { CityDto } from 'src/api/dto/CityDto';

interface IProps {
    favoriteCities : CityDto[]
}

class FavoriteList extends React.Component<IProps> {
    public render() {
        return (
            <ul className="favorite-ul">
                {this.props.favoriteCities.map(c => <li key={c.id} className="favorite-li">{c.name}</li>)}
            </ul>
        )
    }
}

export default FavoriteList;