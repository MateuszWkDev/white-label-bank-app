import React from 'react';

const App: React.FC = () => {
  return (
    <div
      tabIndex={0}
      role="button"
      onClick={e => console.log(e)}
      onKeyPress={e => console.log(e)}
    >
      TEST
    </div>
  );
};

export default App;
