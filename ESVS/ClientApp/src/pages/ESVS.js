import React, { Component } from 'react';
// import styled from 'styled-components';
// import {DataView, DataViewLayoutOptions} from 'primereact/dataview';
import ReactTable from 'react-table';
import 'react-table/react-table.css';

const hm = [["Че-то 1", "ХМммasad", 1],
  ["Че-то 2", "ХМммgg", 4],
  ["Че-то 3", "ХМммsdf", 234],
  ["Че-то 4", "ХМммzxc", 23],
  ["Че-то 5", "ХМмzxcм", 2123],
  ["Че-то 6", "ХМммzxc", 99],
  ["Че-то 7", "ХМzxcмм", 198],
  ["Че-то 8", "ХМasмм", 111],
  ["Че-то 9", "ХМм123м", 12],
  ["Че-то 10", "ХМcsdмм", 13],
  ["Че-то 11", "ХМzxcмм", 111],
  ["Че-то 12", "ХМfsdмм", 1213],
  ["Че-то 13", "ХМ12мм", 10]];

export class ESVS extends Component {
  render() {
    return(
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

