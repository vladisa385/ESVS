// Вспомогательная функция для фильтрации
export const defaultMatcher = (filterText, node) => {
  return node.name.toLowerCase().indexOf(filterText.toLowerCase()) !== -1;
};

export const findNode = (node, filter, matcher) => {
  return matcher(filter, node) || // i-совпадение
    (node.children && // или i имеет детей и один из них подходит
      node.children.length &&
      !!node.children.find(child => findNode(child, filter, matcher)));
};

export const filterTree = (node, filter, matcher = defaultMatcher) => {
  // Если прямое совпадение, то все дети остаются
  if (matcher(filter, node) || !node.children) {
    return node;
  }
  // Если нет, то оставляем тех, кто совпадает или имеет совпадающих детей
  const filtered = node.children
    .filter(child => findNode(child, filter, matcher))
    .map(child => filterTree(child, filter, matcher));
  return Object.assign({}, node, { children: filtered });
};

export const expandFilteredNodes = (node, filter, matcher = defaultMatcher) => {
  let children = node.children;
  if (!children || children.length === 0) {
    return Object.assign({}, node, { toggled: false });
  }
  const childrenWithMatches = node.children.filter(child => findNode(child, filter, matcher));
  const shouldExpand = childrenWithMatches.length > 0;
  // Если нужно развернуть элемент, то проходим через все совпадения и решаем, должны
  // ли дети так же развернуться
  if (shouldExpand) {
    children = childrenWithMatches.map(child => {
      return expandFilteredNodes(child, filter, matcher);
    });
  }
  return Object.assign({}, node, {
    children: children,
    toggled: shouldExpand
  });
};
