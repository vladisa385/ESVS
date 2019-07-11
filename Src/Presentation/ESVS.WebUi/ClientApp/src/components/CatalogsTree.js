import React, { Component } from 'react';
import { TreeSearchField } from './TreeSearchField';
import { Treebeard, decorators } from 'react-treebeard';
import TreeStyle from '../elements/CatalogsTreeStyle';
import styled from 'styled-components';
import { File, Folder } from 'styled-icons/feather';
import Col from 'react-bootstrap/Col';
import { FailedMessage } from '../elements/Misc';

const CatalogsCont = styled.div`
  overflow-x: auto;
  overflow-y: auto;
  white-space: nowrap;
  height: 80vh;
`;

const IconsWrapper = styled.div`
  svg {
    height: 1.3rem;
    width: 1.3rem;
    margin-right: 5px;
    color: #3c99d7;
  }
  :hover {
    color: #3c99d7;
  }
`;

decorators.Header = ({style, node}) => {
  return (
    <IconsWrapper style={style}>
      { node.children.length > 0 ? <Folder /> : <File /> }
      {node.name}
    </IconsWrapper>
  );
};

const Div = styled.div`
  height: 0 !important;
  width: 0 !important;
`;

decorators.Toggle = ({style}) => <Div style={style} />;


export class CatalogsTree extends Component {
  render () {
    const { placeholder, onkeyup, data, ontoggle } = this.props;

    return (
      <React.Fragment>
        <TreeSearchField
          placeholder={placeholder}
          onkeyup={onkeyup}/>
        <CatalogsCont>
        { data.length !== 0 ?
          < Treebeard
            data={data}
            onToggle={ontoggle}
            decorators={decorators}
            style={TreeStyle}/>
            :
            <Col md={12}>
              <FailedMessage>Ничего не найдено</FailedMessage>
            </Col>
        }
        </CatalogsCont>
      </React.Fragment>
    );
  }
}
