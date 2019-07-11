import React, { Component } from 'react';
import ReactTable from 'react-table';
import 'react-table/react-table.css';


export class Table extends Component {
  render() {
    return(
      <ReactTable
        data={this.props.data}
        columns={this.props.columns}
        defaultPageSize={20}
        className="-striped -highlight"
        style={{ height: '100%' }}
        previousText='Предыдущая'
        nextText='Следующая'
        loadingText='Загрузка...'
        noDataText='Данные отсутствуют'
        pageText='Страница'
        ofText='из'
        rowsText='строк'
      />
    );
  }
}
