import React, { Component } from 'react';
import Container from 'react-bootstrap/Container';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import * as filters from '../elements/filter';
import styled from 'styled-components';
import Spinner from '../components/Spinner';
import { CatalogsTree }  from '../components/CatalogsTree';
import { Table } from '../components/Table';
import { FailedMessage } from '../elements/Misc';
import { URL } from '../App'
import { columns as FakeColumns, rows as FakeRows } from '../utils/fake';

const ContainerWrapper = (props) => {
 return (
   <Container className={props.className} fluid={true}>
     {props.children}
   </Container>
 );
};
const Cont = styled(ContainerWrapper)`
  height: 85%;
`;

const RowWrapper = (props) => <Row className={props.className}>{props.children}</Row>;
const StyledRow = styled(RowWrapper).attrs({
  className: 'h-100'
})`
  margin-top: 10px;
`;

const ColWrapper = (props) => <Col className={props.className}>{props.children}</Col>;
const VCentered = styled(ColWrapper).attrs({
  md: 12
})`
  margin-top: auto;
  margin-bottom: auto;
`;

const TableCont = styled.div`
  overflow-y: auto;
  height: 87vh;
`;

const LoadingFailed = styled(FailedMessage)`
  font-size: 25px;
`;


export class ESVS extends Component {
  constructor(props) {
    super(props);
    this.state = {
      data: [],
      loading: true,
      columns: FakeColumns,
      rows: FakeRows,
      loadingFailed: false
    };
    this.data = [];
    this.onToggle = this.onToggle.bind(this);
    this.onFilterMouseUp = this.onFilterMouseUp.bind(this);
    this.getColumns = this.getColumns.bind(this);
  }

  componentDidMount() {
    this.props.goWide();

    function makeTree(arr) {
      let tree = [];

      arr.forEach(i => {
        let children = [];
        let childCatalogs = i['childCatalogs'];
        if (childCatalogs !== null && childCatalogs.length > 0) {
          children = makeTree(childCatalogs);
        }

        tree.push({
            id: i['id'],
            name: i['text'],
            children: children
          });
      });

      return tree;
    }

    fetch('http://' + URL + ':33333/api/Catalogs/GetListCatalogs?PageSize=225', {
      method: 'GET',
      credentials: 'include',
      headers: { 'Accept' : 'application/json' }
    })
      .then(res => {
        if (res.ok) {
          res.json()
            .then(json => {
              let items = json.items;
              let categories = [];
              items.forEach(i => {
                if (i['parentId'] === null) {
                  categories.push(i);
                }
              });
              const treeData = {
                name: '',
                id: '1',
                toggled: true,
                children: makeTree(categories)
              };
              this.setState({ data: treeData });
              this.data = treeData;
              this.setState({ loading: false }); // Убираем спиннер
            })
        }
        else this.setState({ loadingFailed: true });
      })
      .catch(err => {
        console.error(err);
        this.setState({ loadingFailed: true })
      });
  }

  componentWillUnmount() {
    this.props.revertWide();
  }

  getColumns(id) {
    fetch('http://' + URL + ':33333/api/Fields/GetListFields?CatalogId=' + id, {
      method: 'GET',
      credentials: 'include',
      headers: { 'Accept' : 'application/json' }
    })
      .then(res => res.json()
      .then(json => {
        let columns = [];
        json.items.forEach(i => {
          columns.push({
            Header: i.caption,
            accessor: i.id
          })
        });
        this.setState({ columns: columns });
      }))
      .catch(err => console.error(err));
  }

  getRows(id) {
    // УУУУУХ, ДАННЫЕ БЫ ЩАС НЕ СПАРСИТЬ
    fetch('http://' + URL + ':33333/api/FieldValues/GetListFieldValues?FieldId=' + id, {
      method: 'GET',
      credentials: 'include',
      headers: { 'Accept' : 'application/json' }
    })
      .then(res => res.json()
      .then(json => {
        // Тут я их такой получил и что-то делаю
      }))
      .catch(err => console.error(err));
  }

  onToggle(node, toggled) {
    if (node.children) {
      node.toggled = toggled;
    }
    this.setState({ cursor: node });

    if (node.children.length === 0) {
      this.getColumns(node.id);
      this.getRows(node.id);
    }
  }

  onFilterMouseUp(e) {
    const filter = e.target.value.trim();
    if (!filter || filter.length < 2) {
      return this.setState({ data: this.data });
    }
    let filtered = filters.filterTree(this.data, filter);
    filtered = filters.expandFilteredNodes(filtered, filter);
    this.setState({ data: filtered });
  }

  render() {
    const { data, loading, loadingFailed, columns, rows } = this.state;

    return (
      <Cont>
        <StyledRow>
          { loadingFailed ?
            <VCentered>
              <LoadingFailed>Ошибка загрузки</LoadingFailed>
            </VCentered>
            :
            loading ?
            <VCentered>
              <Spinner/>
            </VCentered>
            :
            <React.Fragment>
              <Col md={3}>
                <CatalogsTree
                  data={data.children}
                  placeholder={'Поиск по справочникам...'}
                  ontoggle={this.onToggle}
                  onkeyup={this.onFilterMouseUp} />
              </Col>
              <Col md={9}>
                <TableCont>
                  <Table
                    data={rows}
                    columns={columns} />
                </TableCont>
              </Col>
            </React.Fragment>
          }
        </StyledRow>
      </Cont>
  );
  }
}
