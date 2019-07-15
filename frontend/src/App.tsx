import * as React from 'react';
import './App.css';

import SearchInput from './components/suggest/SearchInput';

class App extends React.Component {
  public render() {
    return (
      <div className="root">
        <SearchInput />
      </div>
    );
  }
}

export default App;
