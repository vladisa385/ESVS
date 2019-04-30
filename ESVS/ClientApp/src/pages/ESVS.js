import React, { Component } from 'react';
// import styled from 'styled-components';
import ReactTable from 'react-table';
import 'react-table/react-table.css';

const hm = [{
  acc1: "Че-то 1",
  acc2: "Хм хм 1",
  acc3: "Первый"
}];

export class ESVS extends Component {
  constructor(props) {
    super(props);
    this.API = 'http://localhost:33333/api/Catalogs/GetListCatalogs';
    this.getCatalogs = this.getCatalogs.bind(this);
  }

  componentDidMount() {
    this.props.goWide();
    fetch(this.API, {
      method: 'GET',
      credentials: 'include',
      headers: {
        'Accept' : 'application/json',
        'Content-Type' : 'application/json'
      }
    })
      .then(res => res.json().then(json => console.log(json)))
      .catch(err => console.error(err));
  }

  componentWillUnmount() {
    this.props.revertWide();
  }

  getCatalogs() {

  }

  render() {
    return (
      <div>
        <ReactTable
          data={hm}
          columns={[
            {
              columns: [
                {
                  Header: "Столбец 1",
                  accessor: "acc1"
                },
                {
                  Header: "Столбец 2",
                  accessor: "acc2"
                },
                {
                  Header: "Столбец 3",
                  accessor: "acc3"
                }
              ]
            }
          ]}
          defaultPageSize={5}
          className="-striped -highlight"
        />
      </div>
    );
  }
}

